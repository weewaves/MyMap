import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { WayPointViewModel } from 'src/app/model/view-model/way-point/way-point-view-model';

@Component({
  selector: 'app-way-point-dialog',
  templateUrl: './way-point-dialog.component.html',
  styleUrls: ['./way-point-dialog.component.scss']
})
export class WayPointDialogComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<WayPointDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public wayPointData: WayPointViewModel) { }

  ngOnInit() {
  }

}
