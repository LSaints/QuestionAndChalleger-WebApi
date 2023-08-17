import { Component, NgModule } from '@angular/core';
import { NavbarComponent } from '../../components/navbar/navbar.component'
import { TableItemsComponent } from '../../components/table-items/table-items.component'


@Component({
  providers: [
    NavbarComponent,
    TableItemsComponent
  ],
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css'],
})
export class IndexComponent {

}
