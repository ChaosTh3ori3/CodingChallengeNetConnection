import {createMap, createMapper} from '@automapper/core';
import {classes} from '@automapper/classes';
import {ReadCategoryDto} from './DTO´s/Category/ReadCategoryDto';
import {Category} from './models/Category';
import {UpdateCategoryDto} from './DTO´s/Category/UpdateCategoryDto';
import {Product} from './models/Product';
import {ReadProductDto} from './DTO´s/Product/ReadProductDto';
import {CreateCategoryDto} from './DTO´s/Category/CreateCategoryDto';

export const mapper = createMapper({
  strategyInitializer: classes()
});

// category
createMap(mapper, ReadCategoryDto, Category);
createMap(mapper, Category, ReadCategoryDto);
createMap(mapper, UpdateCategoryDto, Category);

//Product
createMap(mapper, CreateCategoryDto, Product);
createMap(mapper, Product, ReadProductDto);
