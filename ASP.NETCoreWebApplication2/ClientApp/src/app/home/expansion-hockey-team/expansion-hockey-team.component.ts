import { Component, Input, OnInit } from '@angular/core';
import { HockeyPlayer, Team } from "../home.component";

@Component({
	selector: 'app-expansion-hockey-team',
	templateUrl: './expansion-hockey-team.component.html',
	styleUrls: ['./expansion-hockey-team.component.scss']
})
export class ExpansionHockeyTeamComponent implements OnInit {
	@Input() team!: Team;

	getPlayersByRole(role: number): HockeyPlayer[] {
		return this.team.players.filter(player => player.role === role)
	}

	getSkill(skill?: number): string {
		return !!skill && skill > 0 ? `навык ${skill}` : '';
	}

	constructor() {
	}

	ngOnInit(): void {
	}

}
