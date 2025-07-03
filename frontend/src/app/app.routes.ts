import { Routes } from '@angular/router';
import {ProductComponent} from './content/product/product.component';
import {CategoryComponent} from './content/category/category.component';

export const routes: Routes = [
  { path: 'products', component: ProductComponent },
  { path: 'categories', component: CategoryComponent },
  { path: '', redirectTo: 'products', pathMatch: 'full' }
];
