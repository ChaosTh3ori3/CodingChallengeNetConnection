import { AutoMap } from '@automapper/classes';
import { ReadCategoryDto } from '../Category/ReadCategoryDto';

export class ReadProductDto {
  @AutoMap()
  id: string = '';
  @AutoMap()
  name: string = '';
  @AutoMap()
  description: string = '';
  @AutoMap()
  price: number = 0;
  @AutoMap(() => ReadCategoryDto)
  category: ReadCategoryDto = new ReadCategoryDto();
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
