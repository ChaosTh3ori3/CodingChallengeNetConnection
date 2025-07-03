import { AutoMap } from '@automapper/classes';

export class Category {
  @AutoMap()
  id: string = '';
  @AutoMap()
  name: string = '';
  @AutoMap()
  description?: string = '';
}
