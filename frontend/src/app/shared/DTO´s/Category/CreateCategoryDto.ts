import { AutoMap } from '@automapper/classes';

export class CreateCategoryDto {
  @AutoMap()
  name: string = '';
  @AutoMap()
  description?: string = '';
}
