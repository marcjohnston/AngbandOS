import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyMetadata } from '../../property-metadata';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { SelectOption } from '../../select-option';
import { GameDesignerPropertyEntityComponent } from './game-designer-property-entity.component';

describe('GameDesignerPropertyEntityComponent', () => {
  let fixture: ComponentFixture<GameDesignerPropertyEntityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GameDesignerPropertyEntityComponent]
    }).compileComponents();

    const metadata = new PropertyMetadata(
      'collection', 'monsters', 'Monsters', 'Monsters',
      null, null, null, [], 'key', 'name', 'Monster', null,
    );
    const entity = { key: 'caveTroll', name: 'Cave Troll' };

    fixture = TestBed.createComponent(GameDesignerPropertyEntityComponent);
    fixture.componentRef.setInput('propertyMetadataAndConfiguration', new PropertyMetadataAndConfiguration(metadata, entity));
    fixture.componentRef.setInput('gameConfiguration', { monsters: [entity] });
    fixture.componentRef.setInput('gamePropertyMetadata', [metadata]);
    fixture.componentRef.setInput('enumMap', new Map<string, SelectOption[]>());
    fixture.detectChanges();
  });

  it('should render the selected entity heading', () => {
    const heading: HTMLElement = fixture.nativeElement.querySelector('.collection-property-metadata-title');
    expect(heading.textContent?.trim()).toBe('Monster - Cave Troll');
  });
});
