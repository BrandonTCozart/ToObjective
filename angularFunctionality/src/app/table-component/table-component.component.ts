import { NgClass } from '@angular/common';
import { Component,OnDestroy, OnInit } from '@angular/core';
import { ServiceService } from '../Services/service.service'; 


@Component({
  selector: 'app-table-component',
  templateUrl: './table-component.component.html',
  styleUrls: ['./table-component.component.css'],
})
export class TableComponentComponent implements OnInit {
  constructor(private service: ServiceService) { 
  }
 
  ngOnInit(): void {
    const http$ = this.service.getObjectivesTitles();
    console.log(http$)
    http$.subscribe(
      res => console.log(res),
      err => console.log(err)
    )
  }
    // console.log(this.service.getObjectivesTitles())
    // }
  // displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  // data: any[] = [
  //   {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H'}
  // ];
}
