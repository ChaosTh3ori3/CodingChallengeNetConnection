import { Component } from '@angular/core';
import {MatCard} from '@angular/material/card';
import {
  MatCell,
  MatCellDef,
  MatColumnDef,
  MatHeaderCell,
  MatHeaderCellDef,
  MatHeaderRow, MatHeaderRowDef, MatRow, MatRowDef,
  MatTable
} from '@angular/material/table';
import {Category} from '../../shared/models/Category';
import {Store} from '@ngrx/store';
import {Observable} from 'rxjs';
import {selectAllCategories} from '../../store/category/categories.selector';
import {loadCategories} from '../../store/category/categories.action';
import {MatButton} from '@angular/material/button';

@Component({
  selector: 'app-category',
  imports: [
    MatCard,
    MatTable,
    MatCell,
    MatHeaderCell,
    MatColumnDef,
    MatHeaderCellDef,
    MatCellDef,
    MatHeaderRow,
    MatRowDef,
    MatHeaderRowDef,
    MatRow,
    MatButton
  ],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent {

  categories$: Observable<Category[]>; // Observable for the list of categories
  categories: Category[] = []; // Local array to hold categories

  constructor(private store: Store) {
    this.categories$ = this.store.select(selectAllCategories);
    this.categories$.subscribe(categories => {
      this.categories = categories;
    });
  }
  reloadCategories() {
    this.store.dispatch(loadCategories());
  }

}
