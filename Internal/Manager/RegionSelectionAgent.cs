using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LayeredMapGenAgent.Internal.Manager
{
    internal sealed class RegionLayerSelector
    {

    }

    public static class RegionSelector
    {
        public sealed class MapGenInputData
        {

        }
        public sealed class RegionSelectionOutput
        {

        }


        private static List<RegionLayerSelector> m_regionLayerSelectors = new List<RegionLayerSelector>();


        public static RegionSelectionOutput CalculateRegion(in MapGenInputData mapGenInputData)
        {
            throw new NotImplementedException();
        }
    }
}