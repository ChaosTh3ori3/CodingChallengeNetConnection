import { AutoMap } from '@automapper/classes';

export class ReadCategoryDto {
  @AutoMap()
  id: string = '';
  @AutoMap()
  name: string = '';
  @AutoMap()
  description?: string = '';
}
