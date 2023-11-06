import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";
import { MatToolbarModule } from "@angular/material/toolbar";
import { HomeModule } from "./home/home.module";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    // CounterComponent,
  ],
	imports: [
		BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
		HttpClientModule,
		FormsModule,
		RouterModule.forRoot([
			{ path: '', component: HomeComponent, pathMatch: 'full' },
			// { path: 'counter', component: CounterComponent },
		]),
		BrowserAnimationsModule,
		MatButtonModule,
		MatIconModule,
		MatToolbarModule,
		HomeModule,
	],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
