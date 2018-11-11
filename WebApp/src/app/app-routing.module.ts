import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { IntroComponent } from './intro/intro.component'
import { AlunosComponent } from './alunos/alunos.component'
import { CursosComponent } from './cursos/cursos.component'
import { TurmasComponent } from './turmas/turmas.component'

const routes: Routes = [
  { path: 'intro', component: IntroComponent },
  { path: 'alunos', component: AlunosComponent },
  { path: 'cursos', component: CursosComponent },
  { path: 'turmas', component: TurmasComponent },
  { path: '', redirectTo: '/intro', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }