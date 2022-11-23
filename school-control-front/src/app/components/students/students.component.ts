import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CellClickedEvent, ColDef, GridApi, GridReadyEvent } from 'ag-grid-community';
import { Student } from 'src/app/models/student';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss']
})
export class StudentsComponent implements OnInit {
  students: Student[] = [];
  displayedColumns = ['name', 'academicValue', 'weeklyHours']
  totalCount:number|undefined = 0;
  
  public columnDefs: ColDef[] = [
    { field: 'name'},
    { field: 'address'},
    { field: 'dateOfBirth' }
  ];

  public defaultColDef: ColDef = {
    sortable: true,
    filter: true,
    resizable: true
  };
  private gridApi!: GridApi<Student>;
  constructor(private studentService: StudentService,
    private router: Router) { }

  ngOnInit(): void {
  }

  getData(e: any) {
    console.log(e)
    this.studentService.GetStudents(e)
      .subscribe({
        next: (data) => {
          console.log(data)
          this.students = data.entities as Student[];
          this.totalCount = data.annots.count;
          this.gridApi.sizeColumnsToFit();
        }
      })
  }
  onCellClicked( e: CellClickedEvent): void {
    console.log('cellClicked', e);
    this.router.navigate(['/students',e.data.id,'edit']);
  }
  onGridReady(params: GridReadyEvent<Student>) {
    this.gridApi = params.api;
    this.getData({pageIndex:0, pageSize:10});
  }
}
