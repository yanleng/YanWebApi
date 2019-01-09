import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    title = 'Clients';

   constructor(private _httpService: Http) { }
   apiValues: string[] = [];
   ngOnInit() {
      this._httpService.get('https://localhost:5001/api/employee').subscribe(values => {
         this.apiValues = values.json() as string[];
      });
   }
}
