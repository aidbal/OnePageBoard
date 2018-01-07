/**
 * Test routing
 */
import {RouterModule, Routes} from '@angular/router';
import {PostContainerComponent} from './components/post-container/post-container.component';

const appRoutes: Routes = [
  {path: 'main', component: PostContainerComponent},
  {path: '', redirectTo: 'main', pathMatch: 'full'},
  {path: '**', redirectTo: 'main'}
];
export const routing = RouterModule.forRoot(appRoutes);
