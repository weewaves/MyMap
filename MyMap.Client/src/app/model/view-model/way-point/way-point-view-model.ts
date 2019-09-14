import { Coordinate } from '../../common/coordinate';

export interface WayPointViewModel extends Coordinate {
  'id'?: string;
  'name'?: string;
  'type'?: number;
  'height'?: number;
  'label'?: string;
  'draggable'?: boolean;
}
