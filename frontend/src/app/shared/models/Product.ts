import { AutoMap } from '@automapper/classes';
import {Category} from './Category';

export class Product {
  @AutoMap()
  id: string = '';
  @AutoMap()
  name: string = '';
  @AutoMap()
  description: string = '';
  @AutoMap()
  price: number = 0;
  @AutoMap(() => Category)
  category: Category = new Category();
  @AutoMap()
  imageUrl?: string = '';
  @AutoMap()
  stockQuantity: number = 0;
  @AutoMap()
  sku?: string = '';
  @AutoMap()
  isActive: boolean = true;
  @AutoMap()
  createdAt: Date = new Date();
  @AutoMap()
  updatedAt: Date = new Date();
}
