import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadoDeClientesInactivosComponent } from './listado-de-clientes-inactivos.component';

describe('ListadoDeClientesInactivosComponent', () => {
  let component: ListadoDeClientesInactivosComponent;
  let fixture: ComponentFixture<ListadoDeClientesInactivosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListadoDeClientesInactivosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListadoDeClientesInactivosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
