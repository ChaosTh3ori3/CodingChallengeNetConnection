import { AutoMap } from '@automapper/classes';

export class CreateProductDto {
  @AutoMap()
  name: string = '';
  @AutoMap()
  description: string = '';
  @AutoMap()
  price: number = 0;
  @AutoMap()
  categoryId: string = '';
  @AutoMap()
  imageUrl?: string = '';
  @AutoMap()
  stockQuantity: number = 0;
  @AutoMap()
  sku?: string = '';
  @AutoMap()
  isActive: boolean = true;
}
