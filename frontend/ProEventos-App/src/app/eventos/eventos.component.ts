import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public filteredEvents: any = [];
  public imageShow: boolean = true;
  public imageWidth: number = 150;
  private _listFilter: string = '';

  public get listFilter(): string {
    return this._listFilter;
  }

  public set listFilter(value: string) {
    this._listFilter = value;
    this.filteredEvents = this.listFilter ? this.eventFilter(this.listFilter) : this.eventos;
  }

  eventFilter(filter: string): any {
    filter = filter.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filter) !== -1 ||
                       evento.local.toLocaleLowerCase().indexOf(filter) !== -1
    );
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public imageState(): void {
    this.imageShow = !this.imageShow;
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos')
        .subscribe({
          next: response => {
            this.eventos = response;
            this.filteredEvents = response;
          },
          error: error => console.log(error)
        });
  }

}
