import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExpansionHockeyTeamComponent } from './expansion-hockey-team/expansion-hockey-team.component';
import { MatChipsModule } from "@angular/material/chips";
import { MatDividerModule } from "@angular/material/divider";
import { MatExpansionModule } from "@angular/material/expansion";
import { ScrollToDirective } from "./expansion-hockey-team/scroll-to.directive";

@NgModule({
	declarations: [
		ExpansionHockeyTeamComponent,
		ScrollToDirective
	],
	exports: [
		ExpansionHockeyTeamComponent,
		ScrollToDirective
	],
	imports: [
		CommonModule,
		MatChipsModule,
		MatDividerModule,
		MatExpansionModule
	]
})
export class HomeModule { }
