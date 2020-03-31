using System;

namespace ReadPolygons
{
    internal class Polygon
    {
        public Polygon(double upperLeftLongitude, double upperLeftLatitude, double lowerRightLongitude, double lowerRightLatitude)
        {
            //Verify points are upper left and lower right corners
            if (upperLeftLongitude > 0 && lowerRightLongitude < 0)
            {
                //Spans Crosses 180 and -180
                if (upperLeftLatitude < 0 && lowerRightLatitude > 0)
                {
                    //Spans Crosses 90 and -90; is valid
                }
                else
                {
                    if (upperLeftLatitude <= lowerRightLatitude)
                    {
                        //Corners are not correct
                        throw new ArgumentException("Coordinates do not define the upper left and lower right corners of the box.");
                    }
                }
            }
            else
            {
                if ((upperLeftLongitude >= lowerRightLongitude) ||
                    (upperLeftLatitude <= lowerRightLatitude))
                {
                    //Corners are not correct
                    throw new ArgumentException("Coordinates do not define the upper left and lower right corners of the box.");
                }
            }

            UpperLeftLongitude = upperLeftLongitude;
            UpperLeftLatitude = upperLeftLatitude;
            LowerRightLongitude = lowerRightLongitude;
            LowerRightLatitude = lowerRightLatitude;
        }

        public double UpperLeftLongitude { get; private set; }
        public double UpperLeftLatitude { get; private set; }
        public double LowerRightLongitude { get; private set; }
        public double LowerRightLatitude { get; private set; }
    }
}
