import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuBarComponent } from './menu-bar/menu-bar.component';

@NgModule({
  declarations: [MenuBarComponent],
  imports: [
    CommonModule
  ],
  exports: [
    MenuBarComponent
  ]
})
export class ShellModule { }
