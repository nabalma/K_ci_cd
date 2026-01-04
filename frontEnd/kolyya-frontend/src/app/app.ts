import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TouristicCardComponent } from '../components/touristic-card.component/touristic-card.component';

interface TouristicSite {
  title: string;
  description: string;
  imageUrl: string;
  tag?: string;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TouristicCardComponent],
  templateUrl: './app.html',
  styleUrls: ['./app.scss'],
})
export class AppComponent {
  protected readonly title = signal('kolyya-frontend');

  private readonly sitesData: TouristicSite[] = [
    {
      title: 'Santorin, Grèce',
      description: 'Maisons blanches, couchers de soleil sublimes et mer Égée.',
      imageUrl: 'assets/images/santorini.jpg',
    },
    {
      title: 'Kyoto, Japon',
      description: 'Temples anciens, cerisiers en fleurs et traditions ancestrales.',
      imageUrl: 'assets/images/kyoto.jpg',
    },
    {
      title: 'Bora Bora, Polynésie',
      description: 'Lagons bleus, bungalows sur l’eau et détente absolue.',
      imageUrl: 'assets/images/borabora.jpg',
    },
    {
      title: 'Petra, Jordanie',
      description: 'Cité rose sculptée dans la roche, une merveille.',
      imageUrl: 'assets/images/petra.jpg',
    },
    {
      title: 'Machu Picchu, Pérou',
      description: 'Vestiges incas perchés dans les Andes avec belle vue.',
      imageUrl: 'assets/images/machu.jpg',
    },
  ];

  protected readonly touristicSites = signal(this.sitesData);
}
