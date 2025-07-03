import { AutoMap } from '@automapper/classes';

export class UpdateCategoryDto {
  @AutoMap()
  id: string = '';
  @AutoMap()
  name: string = '';
  @AutoMap()
  description?: string = '';
}
