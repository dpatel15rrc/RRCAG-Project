/*
 * Name: Dharmi Patel
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-09-15
 * Updated: 
 */

namespace Patel.Dharmi.Business
{
    /// <summary>
    /// Specifies the chosen accessories.
    /// </summary>
    public enum Accessories
    {
        /// <summary>
        /// No accessories chosen.
        /// </summary>
        None = 0,

        /// <summary>
        /// Stereo System is chosen.
        /// </summary>
        StereoSystem = 1,

        /// <summary>
        /// Leather interior is chosen.
        /// </summary>
        LeatherInterior = 2,

        /// <summary>
        /// Stereo system and leather interior are chosen.
        /// </summary>
        StereoAndLeather = 3,

        /// <summary>
        /// Computer navigation is chosen.
        /// </summary>
        ComputerNavigation = 4,

        /// <summary>
        /// Stereo System and Computer navigation are chosen. 
        /// </summary>
        StereoAndNavigation = 5,

        /// <summary>
        /// Leather interior and computer navigation are chosen.
        /// </summary>
        LeatherAndNavigation = 6,

        /// <summary>
        /// All (stereo system, leather interiors and computer navigation) are chosen.
        /// </summary>
        All = 7,
    }

}