import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CellClickedEvent, ColDef, GridApi, GridReadyEvent } from 'ag-grid-community';
import { Observable } from 'rxjs';
import { Classes } from 'src/app/models/classes';
import { ClassesService } from 'src/app/services/classes.service';

@Component({
  selector: 'app-classes',
  templateUrl: './classes.component.html',
  styleUrls: ['./classes.component.scss']
})
export class ClassesComponent implements OnInit {

  classes: Classes[] = [];
  displayedColumns = ['name', 'academicValue', 'weeklyHours']
  totalCount:number|undefined = 0;
  
  public columnDefs: ColDef[] = [
    { field: 'name'},
    { field: 'academicValue'},
    { field: 'weeklyHours' }
  ];
  public defaultColDef: ColDef = {
    sortable: true,
    filter: true,
    resizable: true
  };
  private gridApi!: GridApi<Classes>;
  constructor(private classesService: ClassesService,
    private router: Router) { }

  ngOnInit(): void {
  }

  getData(e: any) {
    console.log(e)
    this.classesService.GetClasses(e)
      .subscribe({
        next: (data) => {
          console.log(data)
          this.classes = data.entities as Classes[];
          this.totalCount = data.annots.count;
          this.gridApi.sizeColumnsToFit();
        }
      })
  }
  onCellClicked( e: CellClickedEvent): void {
    console.log('cellClicked', e);
    this.router.navigate(['/classes',e.data.id,'edit']);
  }
  onGridReady(params: GridReadyEvent<Classes>) {
    this.gridApi = params.api;
    this.getData({pageIndex:0, pageSize:10});
  }
}
