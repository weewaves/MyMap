import { Coordinate } from './coordinate';

export interface MapViewPort {
  topRightCorner?: Coordinate;
  bottomRightCorner?: Coordinate;
  bottomLeftCorner?: Coordinate;
  topLeftCorner?: Coordinate;
}
