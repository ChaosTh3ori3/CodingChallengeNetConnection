import {
  APP_INITIALIZER,
  ApplicationConfig,
  importProvidersFrom,
  inject, provideAppInitializer,
  provideZoneChangeDetection
} from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import {provideHttpClient, withInterceptorsFromDi} from '@angular/common/http';
import {environment} from '../../environments/environment.development';
import {StoreDevtoolsModule} from '@ngrx/store-devtools';
import {Store, StoreModule} from '@ngrx/store';
import {EffectsModule} from '@ngrx/effects';
import {appReducers} from './store/app.reducers';
import {categoryReducer} from './store/category/categories.reducer';
import {CategoryEffects} from './store/category/categories.effects';
import {loadCategories} from './store/category/categories.action';

function loadCategoriesInitializer() {
  const store = inject(Store);
  store.dispatch(loadCategories());
}

export const appConfig: ApplicationConfig = {
  providers: [
    importProvidersFrom(
      StoreModule.forRoot(appReducers),
      StoreModule.forFeature('categories', categoryReducer),
      EffectsModule.forRoot([CategoryEffects]),
      !environment.production ? StoreDevtoolsModule.instrument() : []
    ),
    provideAppInitializer(loadCategoriesInitializer),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(withInterceptorsFromDi())]
};
