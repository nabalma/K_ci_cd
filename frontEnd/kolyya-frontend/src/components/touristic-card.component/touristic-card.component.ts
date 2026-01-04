import { ChangeDetectionStrategy, Component, computed, input } from '@angular/core';

@Component({
  selector: 'app-touristic-card',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './touristic-card.component.html',
  styleUrls: ['./touristic-card.component.scss'],
  host: {
    class: 'touristic-card',
  },
})
export class TouristicCardComponent {
  readonly title = input('');
  readonly description = input('');
  readonly imageUrl = input('');
  readonly tag = input<string | null>(null);

  orderCard() {
    const payload = {
      cardTitle: this.title(),
      destination: this.title(), // OK pour l’instant
      orderedBy: 'frontend-user', // 🔥 OBLIGATOIRE
    };

    fetch('http://localhost:5000/api/orders', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(payload),
    })
      .then((res) => {
        if (res.ok) {
          console.log(`✅ Commande envoyée pour ${payload.destination}`);
        } else {
          console.error('❌ Erreur lors de la commande (HTTP)');
        }
      })
      .catch((err) => {
        console.error('❌ Erreur réseau :', err);
      });
  }

  readonly hasTag = computed(() => !!this.tag());
}
