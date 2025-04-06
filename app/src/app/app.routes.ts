import { Routes } from '@angular/router';
import { AppComponent } from './app.component';

export const routes: Routes = [
    { path: '', redirectTo: '/chat', pathMatch: 'full' },
    { path: 'chat', component: AppComponent },
    { path: 'register', component: AppComponent /*AppRegister*/ }, // ADD ONCE REGISTER COMPONENT IS CREATED
    { path: '**', redirectTo: '/chat', pathMatch: 'full' }
];
