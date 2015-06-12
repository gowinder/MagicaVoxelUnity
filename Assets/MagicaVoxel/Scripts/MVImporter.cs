﻿using UnityEngine;
using System.Collections;
using System.IO;

public struct MVColor
{
	public byte r;
	public byte g;
	public byte b;
	public byte a;
}

public struct MVFaceCollection
{
	public byte[,,] colorIndices;
}

public class MVVoxelChunk
{
	// all voxels
	public byte[,,] voxels;
	public MVVoxelChunk[] childChunks;

	// 6 dir, x+. x-, y+, y-, z+, z-
	public MVFaceCollection[] faces;

	public int sizeX { get { return voxels.GetLength (0); } }
	public int sizeY { get { return voxels.GetLength (1); } }
	public int sizeZ { get { return voxels.GetLength (2); } }
}

public enum MVFaceDir
{
	XPlus = 0,
	XNeg  = 1,
	YPlus = 2,
	YNeg  = 3,
	ZPlus = 4,
	ZNeg  = 5
}
		
public class MVVoxelQuadBuffer
{
	Vector3[] vertices;
	Vector2[] uvs;
	Color[] colors;
}

public class MVMainChunk
{
	public MVVoxelChunk voxelChunk;

	public MVColor[] palatte;

	public int sizeX, sizeY, sizeZ;

	public byte[] version;

#region default_palatte
	public static MVColor[] defaultPalatte = new MVColor[] {
		new MVColor { r = 0xff, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0xff, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0xff, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0xff, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0xff, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0xff, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0xff, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0xff, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0xff, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0xff, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0xff, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0xff, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0xff, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0xff, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0xff, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0xff, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0xff, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0xff, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0xff, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0xff, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0xff, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0xff, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0xff, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0xff, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0xff, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0xff, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0xff, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0xff, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0xff, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0xff, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0xff, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0xff, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0xff, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0xff, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0xff, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0xff, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0xcc, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0xcc, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0xcc, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0xcc, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0xcc, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0xcc, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0xcc, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0xcc, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0xcc, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0xcc, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0xcc, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0xcc, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0xcc, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x99, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x99, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x99, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x99, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x99, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x99, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x99, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x99, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x99, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x99, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x99, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x99, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x99, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x99, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x99, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x99, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x99, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x99, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x99, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x99, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x99, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x99, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x99, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x99, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x99, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x99, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x99, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x99, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x99, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x99, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x99, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x99, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x99, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x99, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x99, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x99, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x66, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x66, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x66, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x66, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x66, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x66, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x66, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x66, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x66, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x66, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x66, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x66, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x66, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x66, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x66, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x66, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x66, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x66, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x66, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x66, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x66, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x66, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x66, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x66, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x66, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x66, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x66, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x66, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x66, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x66, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x66, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x66, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x66, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x66, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x66, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x66, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x33, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x33, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x33, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x33, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x33, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x33, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x33, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x33, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x33, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x33, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x33, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x33, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x33, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x33, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x33, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x33, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x33, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x33, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x33, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x33, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x33, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x33, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x33, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x33, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x33, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x33, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x33, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x33, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x33, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x33, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x33, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x33, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x33, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x33, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x33, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x33, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x00, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x00, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x00, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x00, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x00, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x00, g = 0xff, b = 0xff, a = 0xFF },
		new MVColor { r = 0x00, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x00, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x00, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x00, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x00, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x00, g = 0xcc, b = 0xcc, a = 0xFF },
		new MVColor { r = 0x00, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x00, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x00, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x00, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x00, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x00, g = 0x99, b = 0x99, a = 0xFF },
		new MVColor { r = 0x00, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x00, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x00, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x00, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x00, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x00, g = 0x66, b = 0x66, a = 0xFF },
		new MVColor { r = 0x00, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x00, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x00, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x00, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x00, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x00, g = 0x33, b = 0x33, a = 0xFF },
		new MVColor { r = 0x00, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x00, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x00, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x00, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x00, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0xee, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0xdd, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0xbb, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0xaa, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x88, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x77, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x55, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x44, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x22, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x11, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x00, g = 0xee, b = 0xee, a = 0xFF },
		new MVColor { r = 0x00, g = 0xdd, b = 0xdd, a = 0xFF },
		new MVColor { r = 0x00, g = 0xbb, b = 0xbb, a = 0xFF },
		new MVColor { r = 0x00, g = 0xaa, b = 0xaa, a = 0xFF },
		new MVColor { r = 0x00, g = 0x88, b = 0x88, a = 0xFF },
		new MVColor { r = 0x00, g = 0x77, b = 0x77, a = 0xFF },
		new MVColor { r = 0x00, g = 0x55, b = 0x55, a = 0xFF },
		new MVColor { r = 0x00, g = 0x44, b = 0x44, a = 0xFF },
		new MVColor { r = 0x00, g = 0x22, b = 0x22, a = 0xFF },
		new MVColor { r = 0x00, g = 0x11, b = 0x11, a = 0xFF },
		new MVColor { r = 0x00, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x00, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x00, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x00, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x00, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x00, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x00, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x00, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x00, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0x00, g = 0x00, b = 0x00, a = 0xFF },
		new MVColor { r = 0xee, g = 0xee, b = 0xee, a = 0xFF },
		new MVColor { r = 0xdd, g = 0xdd, b = 0xdd, a = 0xFF },
		new MVColor { r = 0xbb, g = 0xbb, b = 0xbb, a = 0xFF },
		new MVColor { r = 0xaa, g = 0xaa, b = 0xaa, a = 0xFF },
		new MVColor { r = 0x88, g = 0x88, b = 0x88, a = 0xFF },
		new MVColor { r = 0x77, g = 0x77, b = 0x77, a = 0xFF },
		new MVColor { r = 0x55, g = 0x55, b = 0x55, a = 0xFF },
		new MVColor { r = 0x44, g = 0x44, b = 0x44, a = 0xFF },
		new MVColor { r = 0x22, g = 0x22, b = 0x22, a = 0xFF },
		new MVColor { r = 0x11, g = 0x11, b = 0x11, a = 0xFF },
		new MVColor { r = 0x00, g = 0x00, b = 0x00, a = 0xFF }
	};
#endregion
}

public static class MVImporter 
{

	public static MVMainChunk LoadVOX(string path)
	{
		byte[] bytes = File.ReadAllBytes (path);
		if (bytes [0] != 'V' ||
		   bytes [1] != 'O' ||
		   bytes [2] != 'X' ||
		   bytes [3] != ' ') {
			throw new FileLoadException ("Invalid VOX file, magic number mismatch");
		}

		MVColor[] colors = new MVColor[] { 
			new MVColor { r = 0xFF, g = 0x1,  b= 0x1, a = 0x1 }, 
			new MVColor { r = 0xFF, g = 0x1,  b= 0x1, a = 0x1 } 
		};

		using (MemoryStream ms = new MemoryStream (bytes)) {
			using (BinaryReader br = new BinaryReader (ms)) {
				MVMainChunk mainChunk = new MVMainChunk ();

				// "VOX "
				br.ReadInt32 ();
				// "VERSION "
				mainChunk.version = br.ReadBytes(4);

				byte[] chunkId = br.ReadBytes (4);
				if (chunkId [0] != 'M' ||
				   chunkId [1] != 'A' ||
				   chunkId [2] != 'I' ||
				   chunkId [3] != 'N') {
					throw new FileLoadException ("Invalid MainChunk ID, main chunk expected");
				}

				int chunkSize = br.ReadInt32 ();
				int childrenSize = br.ReadInt32 ();

				// main chunk should have nothing... skip
				br.ReadBytes (chunkSize); 

				int readSize = 0;
				while (readSize < childrenSize) {
					chunkId = br.ReadBytes (4);
					if (chunkId [0] == 'S' &&
					    chunkId [1] == 'I' &&
					    chunkId [2] == 'Z' &&
					    chunkId [3] == 'E') {

						readSize += ReadSizeChunk (br, mainChunk);

					} else if (chunkId [0] == 'X' &&
					        chunkId [1] == 'Y' &&
					        chunkId [2] == 'Z' &&
					        chunkId [3] == 'I') {

						readSize += ReadVoxelChunk (br, mainChunk.voxelChunk);

					} else if (chunkId [0] == 'R' &&
					        chunkId [1] == 'G' &&
					        chunkId [2] == 'B' &&
					        chunkId [3] == 'A') {

						readSize += ReadPalattee (br, mainChunk.palatte);

					}
					else {
						throw new FileLoadException ("Chunk ID not recognized, got " + System.Text.Encoding.ASCII.GetString(chunkId));
					}
				}

				GenerateFaces (mainChunk.voxelChunk);
				if (mainChunk.palatte == null)
					mainChunk.palatte = MVMainChunk.defaultPalatte;

				return mainChunk;
			}
		}
	}

	static void GenerateFaces(MVVoxelChunk voxelChunk)
	{
		for (int x = 0; x < voxelChunk.sizeX; ++x) {
			for (int y = 0; y < voxelChunk.sizeX; ++y) {
				for (int z = 0; z < voxelChunk.sizeX; ++z) {
					
				}
			}
		}
	}

	static int ReadSizeChunk(BinaryReader br, MVMainChunk mainChunk)
	{
		int chunkSize = br.ReadInt32 ();
		int childrenSize = br.ReadInt32 ();

		mainChunk.sizeX = br.ReadInt32 ();
		mainChunk.sizeY = br.ReadInt32 ();
		mainChunk.sizeZ = br.ReadInt32 ();

		mainChunk.voxelChunk = new MVVoxelChunk ();
		mainChunk.voxelChunk.voxels = new byte[mainChunk.sizeX, mainChunk.sizeY, mainChunk.sizeZ];
		for (int x = 0; x < mainChunk.sizeX; ++x) {
			for (int y = 0; y < mainChunk.sizeX; ++y) {
				for (int z = 0; z < mainChunk.sizeX; ++z) {
					mainChunk.voxelChunk.voxels [x, y, z] = 0;
				}
			}
		}

		Debug.Log (string.Format ("[MVImporter] Voxel Size {0}x{1}x{2}", mainChunk.sizeX, mainChunk.sizeY, mainChunk.sizeZ));

		if (childrenSize > 0) {
			br.ReadBytes (childrenSize);
			Debug.LogWarning ("[MVImporter] Nested chunk not supported");
		}

		return chunkSize + childrenSize + 4 * 3;
	}

	static int ReadVoxelChunk(BinaryReader br, MVVoxelChunk chunk)
	{
		int chunkSize = br.ReadInt32 ();
		int childrenSize = br.ReadInt32 ();

		int numVoxels = br.ReadInt32 ();

		for (int i = 0; i < numVoxels; ++i) {
			int x = (int)br.ReadByte ();
			int y = (int)br.ReadByte ();
			int z = (int)br.ReadByte ();

			chunk.voxels [x, y, z] = br.ReadByte();
		}

		if (childrenSize > 0) {
			br.ReadBytes (childrenSize);
			Debug.LogWarning ("[MVImporter] Nested chunk not supported");
		}

		return chunkSize + childrenSize + 4 * 3;
	}

	static int ReadPalattee(BinaryReader br, MVColor[] colors)
	{
		int chunkSize = br.ReadInt32 ();
		int childrenSize = br.ReadInt32 ();

		for (int i = 0; i < 256; ++i) {
			colors [i].r = br.ReadByte ();
			colors [i].g = br.ReadByte ();
			colors [i].b = br.ReadByte ();
			colors [i].a = br.ReadByte ();
		}

		if (childrenSize > 0) {
			br.ReadBytes (childrenSize);
			Debug.LogWarning ("[MVImporter] Nested chunk not supported");
		}

		return chunkSize + childrenSize + 4 * 3;
	}

	public static Mesh CreateMesh(MVMainChunk chunk)
	{
		return null;
	}

	public static Mesh CreateMeshFromChunk(MVVoxelChunk chunk, MVColor[] palatte)
	{
		return null;
	}

	public static bool ExportToObj(MVMainChunk mv)
	{
		return false;
	}
}
