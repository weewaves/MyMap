import { Coordinate } from '../../common/coordinate';

export interface SpotViewModel extends Coordinate {
  'id'?: string;
  'name'?: string;
  'type'?: number;
  'height'?: number;
  'label'?: string;
  'spotDescription'?: string;
  'vote'?: string;
  'pictureUrls'?: Array<string>;
  'areaId'?: string;
  'draggable'?: boolean;
}
