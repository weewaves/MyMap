import { Coordinate } from './coordinate';

export interface MapRegion {
  topRightCorner?: Coordinate;
  bottomRightCorner?: Coordinate;
  bottomLeftCorner?: Coordinate;
  topLeftCorner?: Coordinate;
}
