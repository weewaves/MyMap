import { Component, OnInit } from '@angular/core';

export enum ARROW_DIRECTION {
  UP = 0,
  DOWN = 1
}

@Component({
  selector: 'app-menu-bar',
  templateUrl: './menu-bar.component.html',
  styleUrls: ['./menu-bar.component.scss']
})
export class MenuBarComponent implements OnInit {
  ARROW_DIRECTION: typeof ARROW_DIRECTION = ARROW_DIRECTION;
  direction: ARROW_DIRECTION;

  constructor() { }

  ngOnInit() {
    this.direction = ARROW_DIRECTION.UP;
  }

  onDownArrowClick(): void {
    this.direction = ARROW_DIRECTION.DOWN;
  }

  onUpArrowClick(): void {
    this.direction = ARROW_DIRECTION.UP;
  }
}
