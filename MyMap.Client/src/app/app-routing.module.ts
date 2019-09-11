import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MapComponent } from './component/map/map.component';
import { ComponentModule } from './component/component.module';

const routes: Routes = [
  { path: '', component: MapComponent, data: { routeName: 'Home' } },
];

@NgModule({
  imports: [
    ComponentModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
