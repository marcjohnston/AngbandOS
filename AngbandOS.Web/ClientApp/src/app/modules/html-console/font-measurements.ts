import { ElementRef } from "@angular/core";


export class FontMeasurements {
    public offsets: { x: number; y: number; }[] = new Array(255); // Full array so that we do not have to check bounds.
    public readonly characterWidth: number = 0;
    public readonly characterHeight: number = 0;

    constructor(canvasRef: ElementRef, font: string) {
        const perCharacterTextMetrics: TextMetrics[] = new Array(255);
        var maxAscent: number | null = null;
        var maxDescent: number | null = null;
        var maxLeft: number | null = null;
        var maxRight: number | null = null;

        const canvas = canvasRef.nativeElement;
        const context = canvas.getContext("2d")!;

        // Use the same baseline/align used when drawing so metrics are consistent.
        context.textBaseline = 'alphabetic'; // Ensure default baseline.
        context.textAlign = 'left'; // This shouldn't make a difference, we will orient accordingly.
        context.font = font;

        // Measure all of the characters.
        for (var asciiIndex = 0; asciiIndex <= 255; asciiIndex++) {
            const characterToMeasure = String.fromCharCode(asciiIndex);
            const textMetrics = context.measureText(characterToMeasure);

            // Store the raw TextMetrics for later per-character calculations.
            perCharacterTextMetrics[asciiIndex] = textMetrics;

            // Compute the maximum bounding rectangle.  Each actual bounding property can be either positive or negative.
            const ascent = textMetrics.actualBoundingBoxAscent;
            const descent = textMetrics.actualBoundingBoxDescent;
            const left = textMetrics.actualBoundingBoxLeft;
            const right = textMetrics.actualBoundingBoxRight;

            if (maxAscent === null || ascent > maxAscent) {
                maxAscent = ascent;
            }
            if (maxDescent === null || descent > maxDescent) {
                maxDescent = descent;
            }
            if (maxLeft === null || left > maxLeft) {
                maxLeft = left;
            }
            if (maxRight === null || right > maxRight) {
                maxRight = right;
            }
        }

        if (maxLeft === null || maxRight === null || maxAscent === null || maxDescent === null) {
            throw new Error("Unable to compute maximum bounding rectangle.");
        }

        // Compute the character dimensions.
        this.characterWidth = maxLeft + maxRight;
        this.characterHeight = maxAscent + maxDescent;

        for (var asciiIndex = 0; asciiIndex <= 255; asciiIndex++) {
            const textMetrics = perCharacterTextMetrics[asciiIndex];

            // Compute the top left of the bounding box.
            const left = textMetrics.actualBoundingBoxLeft;
            const right = textMetrics.actualBoundingBoxRight;
            const ascent = textMetrics.actualBoundingBoxAscent;
            const descent = textMetrics.actualBoundingBoxDescent;
            const width = left + right;

            // Compute an offset that centers the glyph within the cell.
            const x = this.characterWidth / 2 - width / 2; // - left + (-(right + left) / 2 + (this.characterWidth / 2));
            const y = maxAscent; // We are rendering using the 'alphabetic' textbaseline, so no per character ascent is needed.


            // Save the offsets for quick use during drawing.
            this.offsets[asciiIndex] = { x, y };
        }
    }
}
