﻿/****************************************************************************
  Generated by T4TS.tt - don't make any changes in this file
****************************************************************************/

// -- Begin global interfaces
    /** Generated from T4TS.Example.Models.Barfoo **/
    interface Barfoo {
        Number: number;
        Complex: T4TS.OverridenName;
        Name: string;
        DateTime: string;
    }
// -- End global interfaces

module Fooz {
    /** Generated from T4TS.Example.Models.Foobar **/
    export interface IFoobar {
        OverrideAll?: bool;
        Recursive: Fooz.IFoobar;
        NullableInt?: number;
        NullableDouble?: number;
        NestedObjectArr: Barfoo[];
        NestedObjectList: Barfoo[];
        TwoDimensions: string[][];
        ThreeDimensions: Barfoo[][][];
        camelCasePlease: number;
    }
}

module T4TS {
    /** Generated from T4TS.Example.Models.InheritanceTest1 **/
    export interface InheritanceTest1 {
        SomeString: string;
        Recursive: Fooz.IFoobar;
    }
    /** Generated from T4TS.Example.Models.InheritanceTest2 **/
    export interface InheritanceTest2 {
        SomeString2: string;
        Recursive2: Fooz.IFoobar;
    }
    /** Generated from T4TS.Example.Models.InheritanceTest3 **/
    export interface InheritanceTest3 {
        SomeString3: string;
        Recursive3: Fooz.IFoobar;
    }
    /** Generated from T4TS.Example.Models.InheritanceTest4 **/
    export interface InheritanceTest4 {
        SomeString4: string;
        Recursive4: Fooz.IFoobar;
    }
    /** Generated from T4TS.Example.Models.Inherited **/
    export interface OverridenName {
        OtherName?: string;
        Integers: number[];
        Doubles: number[];
        TwoDimList: number[][];
        [index: number]: Barfoo;
    }
}
