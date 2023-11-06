import { Component, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { CommonModule, JsonPipe } from "@angular/common";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { FormArray, FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatCardModule } from "@angular/material/card";
import { MatListModule } from "@angular/material/list";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatButtonModule } from "@angular/material/button";
import { MatSelectModule } from "@angular/material/select";
import { MatButtonToggleModule } from "@angular/material/button-toggle";
import { MatSnackBar, MatSnackBarModule } from "@angular/material/snack-bar";
import { MatExpansionModule } from "@angular/material/expansion";
import { MatChipsModule } from "@angular/material/chips";
import { HomeModule } from "./home.module";

@Component({
	selector: 'app-home',
	templateUrl: './home.component.html',
	styleUrls: ['./home.component.scss'],
	standalone: true,
	imports: [
		FormsModule,
		ReactiveFormsModule,
		MatCheckboxModule,
		JsonPipe,
		MatCardModule,
		MatListModule,
		MatProgressSpinnerModule,
		CommonModule,
		MatButtonModule,
		MatSelectModule,
		MatButtonToggleModule,
		MatSnackBarModule,
		MatExpansionModule,
		MatChipsModule,
		HomeModule
	],
})
export class HomeComponent {
	baseUrl: string;
	formGroup: FormGroup = new FormGroup({});
	formPlayer: FormArray = new FormArray([] as any)
	formPreferredSide: FormControl = new FormControl(false);
	submitButtonState: boolean = false;
	teamCombination: TeamCombination;

	constructor(
		private fb: FormBuilder,
		private httpClient: HttpClient,
		private _snackBar: MatSnackBar,
		@Inject('BASE_URL') baseUrl: string
	) {
		this.baseUrl = baseUrl;
		httpClient.get<HockeyPlayer[]>(`${baseUrl}hockey`)
			.subscribe(result => {
				this.formPlayer = this.fb.array(
					result.map((player) => this.fb.group({
						id: [player.id],
						name: [player.name],
						role: [player.role],
						selected: false,
					}))
				);
				this.formGroup = this.fb.group({
					players: this.formPlayer,
					preferredSide: this.formPreferredSide
				});

			}, error => console.error(error));

	}

	submit() {
		this.submitButtonState = true;
		this.httpClient.post<TeamCombination>(
			`${this.baseUrl}hockey`, JSON.stringify({
				players: this.getSelectedPlayers(),
				preferredSide: this.formPreferredSide.value
			}),
			{
				headers: {
					'Content-Type': 'application/json'
				}
			}).subscribe(
			result => {
				if (!!result.error) {
					this._snackBar.open(result.error, 'OK')
				} else {
					this.teamCombination = result;
					let resultContainer = document.querySelector('.sys__accordion');
					if (!!resultContainer && !this.elementInScopeVertically(resultContainer)) {
						resultContainer.scrollIntoView();
					}
				}
			},
			error => {
				console.error(error);
				this.submitButtonState = false
			},
			() => this.submitButtonState = false);
	}

	elementInScopeVertically(element: Element, topOffset = 0) {
		const rect = element.getBoundingClientRect();
		const viewHeight = Math.max(document.documentElement.clientHeight, window.innerHeight);
		return rect.bottom > topOffset && rect.top - viewHeight < 0;
	}

	getSelectedPlayers(): any[] {
		return (this.formPlayer.value as Array<any>).filter(value => !!value.selected);
	}

	qtySelectedForwards(): number {
		return this.getSelectedPlayers().filter(player => player.role === 1).length
	}

	qtySelectedDefenders(): number {
		return this.getSelectedPlayers().filter(player => player.role === 2).length
	}
}

export interface HockeyPlayer {
	id: number;
	name: string;
	role: number;
}

export interface TeamCombination {
	firstTeam: Team;
	secondTeam: Team;
	error?: string;
}

export interface Team {
	players: HockeyPlayer[],
	teamSide: number;
	skill: TeamSkill,
}

export interface TeamSkill {
	skill?: number;
	skillForwards?: number;
	skillDefenders?: number;
}
