import { Component, OnInit, Inject, OnChanges, SimpleChanges, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { SpotViewModel } from 'src/app/model/view-model/spot/spot-view-model';
import { SpotService } from 'src/app/service/spot/spot.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-spot-dialog',
  templateUrl: './spot-dialog.component.html',
  styleUrls: ['./spot-dialog.component.scss']
})
export class SpotDialogComponent implements OnInit {
  @ViewChild('SpotEditorForm', { read: NgForm, static: false }) spotEditorForm: any;

  internalData: SpotViewModel;
  isLoading: boolean;
  isDataChanged: boolean;

  constructor(
    // tslint:disable-next-line: variable-name
    private _spotService: SpotService,
    // tslint:disable-next-line: variable-name
    private _dialogRef: MatDialogRef<SpotDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public spotData: SpotViewModel) { }

  ngOnInit() {
    this.internalData = Object.assign({}, this.spotData);
  }

  onSave(): void {
    this.isLoading = true;

    this._spotService
      .createSpot(this.spotData)
      .subscribe(
        (res) => {
          console.log(res);
          this.isLoading = false;
          this._dialogRef.close();
        });
  }

  onDataChanged($event: any): void {
    this.isDataChanged = true;
  }

  onCancel(): void {
    this._dialogRef.close();
  }
}
