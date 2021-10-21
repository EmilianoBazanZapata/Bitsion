import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadoDeClientesActivosComponent } from './listado-de-clientes-activos.component';

describe('ListadoDeClientesActivosComponent', () => {
  let component: ListadoDeClientesActivosComponent;
  let fixture: ComponentFixture<ListadoDeClientesActivosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListadoDeClientesActivosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListadoDeClientesActivosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});