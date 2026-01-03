import {
  ChangeDetectionStrategy,
  Component,
  computed,
  signal,
  input,
} from '@angular/core';

@Component({
  selector: 'touristic-card',
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

  readonly hasTag = computed(() => !!this.tag());
}
