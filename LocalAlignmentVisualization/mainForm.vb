'Author: Avery Thorn
'Program: A local alignment visualization tool
'Date: 10/16/2015

Option Strict On
Option Infer Off
Option Explicit On

Imports System.Windows.Forms.DataVisualization.Charting

Public Class mainForm

    Private unsavedResult As Boolean = False          'This will be true when a result has not been saved have been made that haven't been saved
    Private unsavedMatrix As Boolean = False
    Private scoringMatrices As String() = {"DEFAULT", "PAM#", "BLOSUM45", "BLOSUM62", "BLOSUM80", "CUSTOM"}
    Private gapPenaltyTypes As String() = {"Linear", "Constant", "Affine"}

    'this is a list of available amino acids that can be changed at any time to accomodate new amino acids.
    Private aminoAcidList As Char() = {"A"c, "R"c, "N"c, "D"c, "C"c, "Q"c, "E"c, "G"c, "H"c, "I"c, "L"c, "K"c, "M"c,
                                       "F"c, "P"c, "S"c, "T"c, "W"c, "Y"c, "V"c, "B"c, "J"c, "Z"c, "X"c, "*"c}

#Region "Scoring Matrices"
    Private BLOSUM45 As Double(,) = {{5, -2, -1, -2, -1, -1, -1, 0, -2, -1, -1, -1, -1, -2, -1, 1, 0, -2, -2, 0, -1, -1, -1, -1, -5},
                                      {-2, 7, 0, -1, -3, 1, 0, -2, 0, -3, -2, 3, -1, -2, -2, -1, -1, -2, -1, -2, -1, -3, 1, -1, -5},
                                      {-1, 0, 6, 2, -2, 0, 0, 0, 1, -2, -3, 0, -2, -2, -2, 1, 0, -4, -2, -3, 5, -3, 0, -1, -5},
                                      {-2, -1, 2, 7, -3, 0, 2, -1, 0, -4, -3, 0, -3, -4, -1, 0, -1, -4, -2, -3, 6, -3, 1, -1, -5},
                                      {-1, -3, -2, -3, 12, -3, -3, -3, -3, -3, -2, -3, -2, -2, -4, -1, -1, -5, -3, -1, -2, -2, -3, -1, -5},
                                      {-1, 1, 0, 0, -3, 6, 2, -2, 1, -2, -2, 1, 0, -4, -1, 0, -1, -2, -1, -3, 0, -2, 4, -1, -5},
                                      {-1, 0, 0, 2, -3, 2, 6, -2, 0, -3, -2, 1, -2, -3, 0, 0, -1, -3, -2, -3, 1, -3, 5, -1, -5},
                                      {0, -2, 0, -1, -3, -2, -2, 7, -2, -4, -3, -2, -2, -3, -2, 0, -2, -2, -3, -3, -1, -4, -2, -1, -5},
                                      {-2, 0, 1, 0, -3, 1, 0, -2, 10, -3, -2, -1, 0, -2, -2, -1, -2, -3, 2, -3, 0, -2, 0, -1, -5},
                                      {-1, -3, -2, -4, -3, -2, -3, -4, -3, 5, 2, -3, 2, 0, -2, -2, -1, -2, 0, 3, -3, 4, -3, -1, -5},
                                      {-1, -2, -3, -3, -2, -2, -2, -3, -2, 2, 5, -3, 2, 1, -3, -3, -1, -2, 0, 1, -3, 4, -2, -1, -5},
                                      {-1, 3, 0, 0, -3, 1, 1, -2, -1, -3, -3, 5, -1, -3, -1, -1, -1, -2, -1, -2, 0, -3, 1, -1, -5},
                                      {-1, -1, -2, -3, -2, 0, -2, -2, 0, 2, 2, -1, 6, 0, -2, -2, -1, -2, 0, 1, -2, 2, -1, -1, -5},
                                      {-2, -2, -2, -4, -2, -4, -3, -3, -2, 0, 1, -3, 0, 8, -3, -2, -1, 1, 3, 0, -3, 1, -3, -1, -5},
                                      {-1, -2, -2, -1, -4, -1, 0, -2, -2, -2, -3, -1, -2, -3, 9, -1, -1, -3, -3, -3, -2, -3, -1, -1, -5},
                                      {1, -1, 1, 0, -1, 0, 0, 0, -1, -2, -3, -1, -2, -2, -1, 4, 2, -4, -2, -1, 0, -2, 0, -1, -5},
                                      {0, -1, 0, -1, -1, -1, -1, -2, -2, -1, -1, -1, -1, -1, -1, 2, 5, -3, -1, 0, 0, -1, -1, -1, -5},
                                      {-2, -2, -4, -4, -5, -2, -3, -2, -3, -2, -2, -2, -2, 1, -3, -4, -3, 15, 3, -3, -4, -2, -2, -1, -5},
                                      {-2, -1, -2, -2, -3, -1, -2, -3, 2, 0, 0, -1, 0, 3, -3, -2, -1, 3, 8, -1, -2, 0, -2, -1, -5},
                                      {0, -2, -3, -3, -1, -3, -3, -3, -3, 3, 1, -2, 1, 0, -3, -1, 0, -3, -1, 5, -3, 2, -3, -1, -5},
                                      {-1, -1, 5, 6, -2, 0, 1, -1, 0, -3, -3, 0, -2, -3, -2, 0, 0, -4, -2, -3, 5, -3, 1, -1, -5},
                                      {-1, -3, -3, -3, -2, -2, -3, -4, -2, 4, 4, -3, 2, 1, -3, -2, -1, -2, 0, 2, -3, 4, -2, -1, -5},
                                      {-1, 1, 0, 1, -3, 4, 5, -2, 0, -3, -2, 1, -1, -3, -1, 0, -1, -2, -2, -3, 1, -2, 5, -1, -5},
                                      {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                                      {-5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, 1}}
    Private DEFAULT_MATRIX_TEST As Double(,) = {{10, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, 10, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, 10, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, 10, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, 10, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, 10, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, 10, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, 10, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, -9, 10, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, -9, -9, 10, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 10, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 10, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 10, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 10, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 10, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 10, -9, -9, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 10, -9, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 10, -9, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 10, -9, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 10, -9, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 10, -9, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 10, -9, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 10, -9, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 10, -9},
                                            {-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 10}}
    Private DEFAULT_MATRIX As Double(,) = {{2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, 2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, 2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, 2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, 2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, 2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, 2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, 2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, -1, 2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, -1, -1, 2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, -1, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, -1, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, -1, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, -1, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, -1, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, -1, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, -1, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, -1},
                                            {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2}}
    Private BLOSUM62 As Double(,) = {{4, -1, -2, -2, 0, -1, -1, 0, -2, -1, -1, -1, -1, -2, -1, 1, 0, -3, -2, 0, -2, -1, -1, 0, -4},
                                      {-1, 5, 0, -2, -3, 1, 0, -2, 0, -3, -2, 2, -1, -3, -2, -1, -1, -3, -2, -3, -1, -2, 0, -1, -4},
                                      {-2, 0, 6, 1, -3, 0, 0, 0, 1, -3, -3, 0, -2, -3, -2, 1, 0, -4, -2, -3, 3, 0, -3, -1, -4},
                                      {-2, -2, 1, 6, -3, 0, 2, -1, -1, -3, -4, -1, -3, -3, -1, 0, -1, -4, -3, -3, 4, -3, 1, -1, -4},
                                      {0, -3, -3, -3, 0, -3, -4, -3, -3, -1, -1, -3, -1, -2, -3, -1, -1, -2, -2, -1, -3, -1, -3, -2, -4},
                                      {-1, 1, 0, 0, -3, 5, 2, -2, 0, -3, -2, 1, 0, -3, -1, 0, -1, -2, -1, -2, 0, -2, 3, -1, -4},
                                      {-1, 0, 0, 2, -4, 2, 5, -2, 0, -3, -3, 1, -2, -3, -1, 0, -1, -3, -2, -2, 1, -3, 4, -1, -4},
                                      {0, -2, 0, -1, -3, -2, -2, 6, -2, -4, -4, -2, -3, -3, -2, 0, -2, -2, -3, -3, -1, -4, -2, -1, -4},
                                      {-2, 0, 1, -1, -3, 0, 0, -2, 8, -3, -3, -1, -2, -1, -2, -1, -2, -2, 2, -3, 0, 0, -3, -1, -4},
                                      {-1, -3, -3, -3, -1, -3, -3, -4, -3, 4, 2, -3, 1, 0, -3, -2, -1, -3, -1, 3, -3, 3, -3, -1, -4},
                                      {-1, -2, -3, -4, -1, -2, -3, -4, -3, 2, 4, -2, 2, 0, -3, -2, -1, -2, -1, 1, -4, 3, -3, -1, -4},
                                      {-1, 2, 0, -1, -3, 1, 1, -2, -1, -3, -2, 5, -1, -3, -1, 0, -1, -3, -2, -2, 0, -3, 1, -1, -4},
                                      {-1, -1, -2, -3, -1, 0, -2, -3, -2, 1, 2, -1, 5, 0, -2, -1, -1, -1, -1, 1, -3, 2, -1, -1, -4},
                                      {-2, -3, -3, -3, -2, -3, -3, -3, -1, 0, 0, -3, 0, 6, -4, -2, -2, 1, 3, -1, -3, 0, -3, -1, -4},
                                      {-1, -2, -2, -1, -3, -1, -1, -2, -2, -3, -3, -1, -2, -4, 7, -1, -1, -4, -3, -2, -2, -3, -1, -2, -4},
                                      {1, -1, 1, 0, -1, 0, 0, 0, -1, -2, -2, 0, -1, -2, -1, 4, 1, -3, -2, -2, 0, -2, 0, 0, -4},
                                      {0, -1, 0, -1, -1, -1, -1, -2, -2, -1, -1, -1, -1, -2, -1, 1, 5, -2, -2, 0, -1, -1, -1, 0, -4},
                                      {-3, -3, -4, -4, -2, -2, -3, -2, -2, -3, -2, -3, -1, 1, -4, -3, -2, 11, 2, -3, -4, -2, -3, -2, -4},
                                      {-2, -2, -2, -3, -2, -1, -2, -3, 2, -1, -1, -2, -1, 3, -3, -2, -2, 2, 7, -1, -3, -1, -2, -1, -4},
                                      {0, -3, -3, -3, -1, -2, -2, -3, -3, 3, 1, -2, 1, -1, -2, -2, 0, -3, -1, 4, -3, 2, -2, -1, -4},
                                      {-2, -1, 3, 4, -3, 0, 1, -1, 0, -3, -4, 0, -3, -3, -2, 0, -1, -4, -3, -3, 4, -3, 1, -1, -4},
                                      {-1, -2, -3, -3, -1, -2, -3, -4, -3, 3, 3, -3, 2, 0, -3, -2, -1, -2, -1, 2, -3, 3, -3, -1, -4},
                                      {-1, 0, 0, 1, -3, 3, 4, -2, 0, -3, -3, 1, -1, -3, -1, 0, -1, -3, -2, -2, 1, -3, 4, -1, -4},
                                      {0, -1, -1, -1, -2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -2, 0, 0, -2, -1, -1, -1, -1, -1, -1, -4},
                                      {-4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -1}}
    Private BLOSUM80 As Double(,) = {{5, -2, -2, -2, -1, -1, -1, 0, -2, -2, -2, -1, -1, -3, -1, 1, 0, -3, -2, 0, -2, -2, -1, -1, -6},
                                      {-2, 6, -1, -2, -4, 1, -1, -3, 0, -3, -3, 2, -2, -4, -2, -1, -1, -4, -3, -3, -1, -3, 0, -1, -6},
                                      {-2, -1, 6, 1, -3, 0, -1, -1, 0, -4, -4, 0, -3, -4, -3, 0, 0, -4, -3, -4, 5, -4, 0, -1, -6},
                                      {-2, -2, 1, 6, -4, -1, 1, -2, -2, -4, -5, -1, -4, -4, -2, -1, -1, -6, -4, -4, 5, -5, 1, -1, -6},
                                      {-1, -4, -3, -4, 9, -4, -5, -4, -4, -2, -2, -4, -2, -3, -4, -2, -1, -3, -3, -1, -4, -2, -4, -1, -6},
                                      {-1, 1, 0, -1, -4, 6, 2, -2, 1, -3, -3, 1, 0, -4, -2, 0, -1, -3, -2, -3, 0, -3, 4, -1, -6},
                                      {-1, -1, -1, 1, -5, 2, 6, -3, 0, -4, -4, 1, -2, -4, -2, 0, -1, -4, -3, -3, 1, -4, 5, -1, -6},
                                      {0, -3, -1, -2, -4, -2, -3, 6, -3, -5, -4, -2, -4, -4, -3, -1, -2, -4, -4, -4, -1, -5, -3, -1, -6},
                                      {-2, 0, 0, -2, -4, 1, 0, -3, 8, -4, -3, -1, -2, -2, -3, -1, -2, -3, 2, -4, -1, -4, 0, -1, -6},
                                      {-2, -3, -4, -4, -2, -3, -4, -5, -4, 5, 1, -3, 1, -1, -4, -3, -1, -3, -2, 3, -4, 3, -4, -1, -6},
                                      {-2, -3, -4, -5, -2, -3, -4, -4, -3, 1, 4, -3, 2, 0, -3, -3, -2, -2, -2, 1, -4, 3, -3, -1, -6},
                                      {-1, 2, 0, -1, -4, 1, 1, -2, -1, -3, -3, 5, -2, -4, -1, -1, -1, -4, -3, -3, -1, -3, 1, -1, -6},
                                      {-1, -2, -3, -4, -2, 0, -2, -4, -2, 1, 2, -2, 6, 0, -3, -2, -1, -2, -2, 1, -3, 2, -1, -1, -6},
                                      {-3, -4, -4, -4, -3, -4, -4, -4, -2, -1, 0, -4, 0, 6, -4, -3, -2, 0, 3, -1, -4, 0, -4, -1, -6},
                                      {-1, -2, -3, -2, -4, -2, -2, -3, -3, -4, -3, -1, -3, -4, 8, -1, -2, -5, -4, -3, -2, -4, -2, -1, -6},
                                      {1, -1, 0, -1, -2, 0, 0, -1, -1, -3, -3, -1, -2, -3, -1, 5, 1, -4, -2, -2, 0, -3, 0, -1, -6},
                                      {0, -1, 0, -1, -1, -1, -1, -2, -2, -1, -2, -1, -1, -2, -2, 1, 5, -4, -2, 0, -1, -1, -1, -1, -6},
                                      {-3, -4, -4, -6, -3, -3, -4, -4, -3, -3, -2, -4, -2, 0, -5, -4, -4, 11, 2, -3, -5, -3, -3, -1, -6},
                                      {-2, -3, -3, -4, -3, -2, -3, -4, 2, -2, -2, -3, -2, 3, -4, -2, -2, 2, 7, -2, -3, -2, -3, -1, -6},
                                      {0, -3, -4, -4, -1, -3, -3, -4, -4, 3, 1, -3, 1, -1, -3, -2, 0, -3, -2, 4, -4, 2, -3, -1, -6},
                                      {-2, -1, 5, 5, -4, 0, 1, -1, -1, -4, -4, -1, -3, -4, -2, 0, -1, -5, -3, -4, 5, -4, 0, -1, -6},
                                      {-2, -3, -4, -5, -2, -3, -4, -5, -4, 3, 3, -3, 2, 0, -4, -3, -1, -3, -2, 2, -4, 3, -3, -1, -6},
                                      {-1, 0, 0, 1, -4, 4, 5, -3, 0, -4, -3, 1, -1, -4, -2, 0, -1, -3, -3, -3, 0, -3, 5, -1, -6},
                                      {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -6},
                                      {-6, -6, -6, -6, -6, -6, -6, -6, -6, -6, -6, -6, -6, -6, -6, -6, -6, -6, -6, -6, -6, -6, -6, -6, 1}}
    Private PAM250 As Double(,) = {{-2, -1, 0, 0, -2, 0, 0, 1, -1, -1, -2, -1, -1, -3, 1, 1, 1, -6, -3, 0, 0, 0, 0, 0, -8},
                                    {-2, 6, 0, -1, -4, 1, -1, -3, 2, -2, -3, 3, 0, -4, 0, 0, -1, 2, -4, -2, -1, 0, 0, -1, -8},
                                    {0, 0, 2, 2, -4, 1, 1, 0, 2, -2, -3, 1, -2, -3, 0, 1, 0, -4, -2, -2, 2, 0, 1, 0, -8},
                                    {0, -1, 2, 4, -5, 2, 3, 1, 1, -2, -4, 0, -3, -6, -1, 0, 0, -7, -4, -2, 3, 0, 3, -1, -8},
                                    {-2, -4, -4, -5, 12, -5, -5, -3, -3, -2, -6, -5, -5, -4, -3, 0, -2, -8, 0, -2, -4, 0, -5, -3, -8},
                                    {0, 1, 1, 2, -5, 4, 2, -1, 3, -2, -2, 1, -1, -5, 0, -1, -1, -5, -4, -2, 1, 0, 3, -1, -8},
                                    {0, -1, 1, 3, -5, 2, 4, 0, 1, -2, -3, 0, -2, -5, -1, 0, 0, -7, -4, -2, 3, 0, 3, -1, -8},
                                    {1, -3, 0, 1, -3, -1, 0, 5, -2, -3, -4, -2, -3, -5, 0, 1, 0, -7, -5, -1, 0, 0, 0, -1, -8},
                                    {-1, 2, 2, 1, -3, 3, 1, -2, 6, -2, -2, 0, -2, -2, 0, -1, -1, -3, 0, -2, 1, 0, 2, -1, -8},
                                    {-1, -2, -2, -2, -2, -2, -2, -3, -2, 5, 2, -2, 2, 1, -2, -1, 0, -5, -1, 4, -2, 0, -2, -1, -8},
                                    {-2, -3, -3, -4, -6, -2, -3, -4, -2, -2, 6, -3, 4, 2, -3, -3, -2, -2, -1, 2, -3, 0, -3, -1, -8},
                                    {-1, 3, 1, 0, -5, 1, 0, -2, 0, -2, -3, 5, 0, -5, -1, 0, 0, -3, -4, -2, 1, 0, 0, -1, -8},
                                    {-1, 0, -2, -3, -5, -1, -2, -3, -2, 2, 4, 0, 6, 0, -2, -2, -1, -4, -2, 2, -2, 0, -2, -1, -8},
                                    {-3, -4, -3, -6, -4, -5, -5, -5, -2, 1, 2, -5, 0, 9, -5, -3, -3, 0, 7, -1, -4, 0, -5, -2, -8},
                                    {1, 0, 0, -1, -3, 0, -1, 0, 0, -2, -3, -1, -2, -5, 6, 1, 0, -6, -5, -1, -1, 0, 0, -1, -8},
                                    {1, 0, 1, 0, 0, -1, 0, 1, -1, -1, -3, 0, -2, -3, 1, 2, 1, -2, -3, -1, 0, 0, 0, 0, -8},
                                    {1, -1, 0, 0, -2, -1, 0, 0, -1, 0, -2, 0, -1, -3, 0, 1, 3, -5, -3, 0, 0, 0, -1, 0, -8},
                                    {-6, 2, -4, -7, -8, -5, -7, -7, -3, -5, -2, -3, -4, 0, -6, -2, -5, 17, 0, -6, -5, 0, -6, -4, -8},
                                    {-3, -4, -2, -4, 0, -4, -4, -5, 0, -1, -1, -4, -2, 7, -5, -3, -3, 0, 10, -2, -3, 0, -4, -2, -8},
                                    {0, -2, -2, -2, -2, -2, -2, -1, -2, 4, 2, -2, 2, -1, -1, -1, 0, -6, -2, 4, -2, 0, -2, -1, -8},
                                    {0, -1, 2, 3, -4, 1, 3, 0, 1, -2, -3, 1, -2, -4, -1, 0, 0, -5, -3, -2, 3, 0, 2, -1, -8},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -8},
                                    {0, 0, 1, 3, -5, 3, 3, 0, 2, -2, -3, 0, -2, -5, 0, 0, -1, -6, -4, -2, 2, 0, 3, -1, -8},
                                    {0, -1, 0, -1, -3, -1, -1, -1, -1, -1, -1, -1, -1, -2, -1, 0, 0, -4, -2, -1, -1, 0, -1, -1, -8},
                                    {-8, -8, -8, -8, -8, -8, -8, -8, -8, -8, -8, -8, -8, -8, -8, -8, -8, -8, -8, -8, -8, -8, -8, -8, 1}}
    Private PAM1 As Double(,) = {{9867, 1, 4, 6, 1, 3, 10, 21, 1, 2, 3, 2, 1, 1, 13, 28, 22, 0, 1, 13, 0, 0, 0, 0, 0},
                                  {2, 9913, 1, 0, 1, 9, 0, 1, 8, 2, 1, 37, 1, 1, 5, 11, 2, 2, 0, 2, 0, 0, 0, 0, 0},
                                  {9, 1, 9822, 42, 0, 4, 7, 12, 18, 3, 3, 25, 0, 1, 2, 34, 13, 0, 2, 1, 0, 0, 0, 0, 0},
                                  {10, 0, 36, 9859, 0, 5, 56, 11, 3, 1, 0, 6, 0, 0, 1, 7, 4, 0, 0, 1, 0, 0, 0, 0, 0},
                                  {3, 1, 0, 0, 9973, 0, 0, 1, 1, 2, 0, 0, 0, 0, 1, 11, 1, 0, 3, 3, 0, 0, 0, 0, 0},
                                  {8, 10, 4, 6, 0, 9876, 35, 3, 20, 1, 6, 12, 2, 0, 8, 4, 3, 0, 0, 2, 0, 0, 0, 0, 0},
                                  {17, 0, 6, 53, 0, 27, 9865, 7, 1, 2, 1, 7, 0, 0, 3, 6, 2, 0, 1, 2, 0, 0, 0, 0, 0},
                                  {21, 0, 6, 6, 0, 1, 4, 9935, 0, 0, 1, 2, 0, 1, 2, 16, 2, 0, 0, 3, 0, 0, 0, 0, 0},
                                  {2, 10, 21, 4, 1, 23, 2, 1, 9912, 0, 4, 2, 0, 2, 5, 2, 1, 0, 4, 3, 0, 0, 0, 0, 0},
                                  {6, 3, 3, 1, 1, 1, 3, 0, 0, 9872, 22, 4, 5, 8, 1, 2, 11, 0, 1, 57, 0, 0, 0, 0, 0},
                                  {4, 1, 1, 0, 0, 3, 1, 1, 1, 9, 9947, 1, 8, 6, 2, 1, 2, 0, 1, 11, 0, 0, 0, 0, 0},
                                  {2, 19, 13, 3, 0, 6, 4, 2, 1, 2, 2, 9926, 4, 0, 2, 7, 8, 0, 0, 1, 0, 0, 0, 0, 0},
                                  {6, 4, 0, 0, 0, 4, 1, 1, 0, 12, 45, 20, 9874, 4, 1, 4, 6, 0, 0, 17, 0, 0, 0, 0, 0},
                                  {2, 1, 1, 0, 0, 0, 0, 1, 2, 7, 13, 0, 1, 9946, 1, 3, 1, 1, 21, 1, 0, 0, 0, 0, 0},
                                  {22, 4, 2, 1, 1, 6, 3, 3, 3, 0, 3, 3, 0, 0, 9926, 17, 5, 0, 0, 3, 0, 0, 0, 0, 0},
                                  {35, 6, 20, 5, 5, 2, 4, 21, 1, 1, 1, 8, 1, 2, 12, 9840, 32, 1, 1, 2, 0, 0, 0, 0, 0},
                                  {32, 1, 9, 3, 1, 2, 2, 3, 1, 7, 3, 11, 2, 1, 4, 38, 9871, 0, 1, 10, 0, 0, 0, 0, 0},
                                  {0, 8, 1, 0, 0, 0, 0, 0, 1, 0, 4, 0, 0, 3, 0, 5, 0, 9976, 2, 0, 0, 0, 0, 0, 0},
                                  {2, 0, 4, 0, 3, 0, 1, 0, 4, 1, 2, 1, 0, 28, 0, 2, 2, 1, 9945, 2, 0, 0, 0, 0, 0},
                                  {18, 1, 1, 1, 2, 1, 2, 5, 1, 33, 15, 1, 4, 0, 2, 2, 9, 0, 1, 9901, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}}
#End Region

    Private currentScoringMatrix(24, 24) As Double
    Private lastCustomMatrix(24, 24) As Double
    Private currentResult As Result = Nothing
    Private currentlyDisplayedAlignment As Integer = -1
    Private resultsPanelsArray(4) As Panel
    Private statsPanel As Panel
    Public debugLog As List(Of String) = New List(Of String)
    Private compareResult(3) As Result
    Private firstTimeViewingComparativeChart As Boolean = True

    Private alignmentContainsPartialPathMatrix(-1, -1) As Boolean

    Enum GAP_TYPE
        AFFINE
        LINEAR
        CONSTANT
    End Enum
    Enum DISPLAY
        GRID
        SEQUENCE
    End Enum
    Enum ALIGNMENT_TYPE
        MATCH
        MISMATCH
        GAP_IN_SEQUENCE1
        GAP_IN_SEQUENCE2
    End Enum

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'center form on screen
            Dim r As Rectangle
            If Parent IsNot Nothing Then
                r = Parent.RectangleToScreen(Parent.ClientRectangle)
            Else
                r = Screen.FromPoint(Me.Location).WorkingArea
            End If

            Dim x As Integer = CInt(Math.Round(r.Left + (r.Width - Me.Width) \ 2))
            Dim y As Integer = CInt(Math.Round(r.Top + (r.Height - Me.Height) \ 2))
            Me.Location = New Point(x, y)

            'update settings and pam matrix
            updateSettings()
            getPAMProbMat()

            'set scoring matrix dropdownlist
            For Each s As String In scoringMatrices
                scoringMatrixComboBox.Items.Add(s)
            Next
            scoringMatrixComboBox.SelectedIndex = 0

            'set gap penalty dropdownlist
            For Each s As String In gapPenaltyTypes
                gapPenaltyCB.Items.Add(s)
            Next
            gapPenaltyCB.SelectedIndex = 2

            penaltyValueTextbox.Text = "-10"
            penaltyValueTwoTextbox.Text = "-0.05"

            useScoringMatrixCB.Checked = False

            'set mismatch threshold dropdownlist
            ignoreIntersectionsCB.Checked = True

            'disable suboptimal alignment navigation
            suboptimalLeftButton.Visible = False
            suboptimalRightButton.Visible = False
            suboptimalFirstButton.Visible = False
            suboptimalLastButton.Visible = False

            viewCombobox.Items.Add("Grid View")
            viewCombobox.Items.Add("Sequence View")
            viewCombobox.Items.Add("Partial Path View")
            viewCombobox.Items.Add("Dot Plot View")
            viewCombobox.Items.Add("Density Color View")
            viewCombobox.SelectedIndex = 0

            orderByComboBox.Items.Add("Score")
            orderByComboBox.Items.Add("Length")
            orderByComboBox.Items.Add("Number of Gaps")
            orderByComboBox.Items.Add("Number of Matches")
            orderByComboBox.Items.Add("Number of Mismatches")
            orderByComboBox.SelectedIndex = 0

            orderByLabel.Visible = False
            orderByComboBox.Visible = False

            zoomToActualButton.Enabled = False
            zoomToFitButton.Enabled = False
            zoomToActualButton.Checked = True
            ZoomToFitToolStripMenuItem.Enabled = False
            ZoomToActualSizeToolStripMenuItem.Enabled = False

            DisplaySequence1NumbersToolStripMenuItem.Checked = My.Settings.DisplaySequence1Numbers
            DisplaySequence2NumbersToolStripMenuItem.Checked = My.Settings.DisplaySequence2Numbers
            ViewFullTracebackGraphToolStripMenuItem.Checked = My.Settings.ViewFullTracebackGraph
            DimMismatchesToolStripMenuItem.Checked = My.Settings.DimMismatches
            ShowGridLinesToolStripMenuItem.Checked = My.Settings.ShowGridLinesPartialPath
            DensityColorSimilarityMatchingToolStripMenuItem.Checked = My.Settings.SequenceDensityColors
            UseColorsToolStripMenuItem.Checked = My.Settings.DotPlotInColor
            ShowGridLinesToolStripMenuItemDotPlot.Checked = My.Settings.ShowGridLinesDotPlot
            ShowGridLinesToolStripMenuItemDensityColor.Checked = My.Settings.ShowGridLinesDensityColor
            UseWindowingToolStripMenuItem.Checked = My.Settings.UseWindowingForDotPlot
            SimpleSequenceLineViewToolStripMenuItem.Checked = My.Settings.SimpleSequenceLineView

            matchesGapsDCButton.Visible = False
            gapsOnlyDCButton.Visible = False
            matchesOnlyDCButton.Visible = False

            GapsOnlyToolStripMenuItem.Enabled = False
            MatchesOnlyToolStripMenuItem.Enabled = False
            MatchesAndGapsToolStripMenuItem.Enabled = False

            For Each item As ToolStripMenuItem In mainMenu.Items
                If item.Name = "SettingsToolStripMenuItem" Then
                    item.DropDownItems.Insert(0, New ToolStripSeparator)
                    item.DropDownItems.Insert(0, New ToolStripControlHost(New Label With {
                                                                          .Text = "Sequence View Settings",
                                                                          .BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0),
                                                                          .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Bold)
                                                                      }))
                    item.DropDownItems.Insert(7, New ToolStripSeparator)
                    item.DropDownItems.Insert(7, New ToolStripControlHost(New Label With {
                                                                          .Text = "Partial Path View Settings",
                                                                          .BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0),
                                                                          .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Bold)
                                                                      }))
                    item.DropDownItems.Insert(11, New ToolStripSeparator)
                    item.DropDownItems.Insert(11, New ToolStripControlHost(New Label With {
                                                                          .Text = "Dot Plot View Settings",
                                                                          .BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0),
                                                                          .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Bold)
                                                                      }))
                    item.DropDownItems.Insert(16, New ToolStripSeparator)
                    item.DropDownItems.Insert(16, New ToolStripControlHost(New Label With {
                                                                          .Text = "Density Color Plot View Settings",
                                                                          .BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0),
                                                                          .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Bold)
                                                                      }))
                    item.DropDownItems.Insert(22, New ToolStripSeparator)
                    item.DropDownItems.Insert(22, New ToolStripControlHost(New Label With {
                                                                          .Text = "General",
                                                                          .BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0),
                                                                          .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Bold)
                                                                      }))
                End If
                If item.Name = "FileToolStripMenuItem" Then
                    item.DropDownItems.Insert(0, New ToolStripSeparator)
                    item.DropDownItems.Insert(0, New ToolStripControlHost(New Label With {
                                                                          .Text = "File Settings",
                                                                          .BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0),
                                                                          .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Bold)
                                                                      }))
                End If
                If item.Name = "ViewToolStripMenuItem" Then
                    item.DropDownItems.Insert(0, New ToolStripSeparator)
                    item.DropDownItems.Insert(0, New ToolStripControlHost(New Label With {
                                                                          .Text = "Result View",
                                                                          .BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0),
                                                                          .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Bold)
                                                                      }))
                    item.DropDownItems.Insert(7, New ToolStripSeparator)
                    item.DropDownItems.Insert(7, New ToolStripControlHost(New Label With {
                                                                          .Text = "Order Alignments View",
                                                                          .BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0),
                                                                          .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Bold)
                                                                      }))
                    item.DropDownItems.Insert(14, New ToolStripSeparator)
                    item.DropDownItems.Insert(14, New ToolStripControlHost(New Label With {
                                                                          .Text = "Zooming",
                                                                          .BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0),
                                                                          .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Bold)
                                                                      }))
                End If
            Next

            'set initial scoring matrix
            For i As Integer = 0 To DEFAULT_MATRIX.GetUpperBound(0)
                For j As Integer = 0 To DEFAULT_MATRIX.GetUpperBound(1)
                    currentScoringMatrix(i, j) = DEFAULT_MATRIX(i, j)
                    lastCustomMatrix(i, j) = DEFAULT_MATRIX(i, j)
                Next
            Next
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show(ex.toString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            displayLog()
        End Try
    End Sub
    Private Sub clearInputValues()
        seq1Rtextbox.Text = String.Empty
        seq2Rtextbox.Text = String.Empty
        matchValueTextbox.Text = String.Empty
        mismatchValueTextbox.Text = String.Empty
        optimalThresholdTextbox.Text = String.Empty
        eValueRB.Checked = False
        useScoringMatrixCB.Checked = False
        penaltyValueTextbox.Text = String.Empty
        penaltyValueTwoTextbox.Text = String.Empty
        ignoreIntersectionsCB.Checked = True
    End Sub
    Private Function getPAMProbMat() As Double(,)
        Try
            For i As Integer = 0 To PAM1.GetUpperBound(0)
                Dim currentRowTotal As Double = 0
                For j As Integer = 0 To PAM1.GetUpperBound(1)
                    currentRowTotal += PAM1(i, j)
                Next
                If currentRowTotal > 0 Then
                    For j As Integer = 0 To PAM1.GetUpperBound(1)
                        PAM1(i, j) /= currentRowTotal
                    Next
                End If
            Next
            Return PAM1
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show(ex.toString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            displayLog()
            Return Nothing
        End Try
    End Function
    Public Sub updateSettings()
        Try
            'set sequence tooltips
            Dim AAlist As String = getAminoAcidList()
            If My.Settings.DNACharsOnly Then
                infoToolTip.SetToolTip(seq1QMTT, "Only DNA characters are allowed. The following are acceptable DNA Characters:" &
                                   Environment.NewLine & AAlist &
                                   Environment.NewLine & Environment.NewLine & "This can be disabled under settings")
                infoToolTip.SetToolTip(seq2QMTT, "Only DNA characters are allowed. The following are acceptable DNA Characters:" &
                                   Environment.NewLine & AAlist &
                                   Environment.NewLine & Environment.NewLine & "This can be disabled under settings")
            Else
                infoToolTip.SetToolTip(seq1QMTT, "All characters are allowed, not just DNA characters" & Environment.NewLine &
                                   Environment.NewLine & "This can be enabled under settings")
                infoToolTip.SetToolTip(seq2QMTT, "All characters are allowed, not just DNA characters" & Environment.NewLine &
                                   Environment.NewLine & "This can be enabled under settings")
            End If
            If currentlyDisplayedAlignment <> -1 Then
                displayAlignment(currentlyDisplayedAlignment)
            End If
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show(ex.toString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            displayLog()
        End Try
    End Sub
    Private Function getAminoAcidList() As String
        Try
            Dim retStr As String = String.Empty
            For Each c As Char In aminoAcidList
                retStr &= c & ", "
            Next
            Return retStr.Substring(0, retStr.Length - 3) & "and " & retStr.Substring(retStr.Length - 3, 1)
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show(ex.toString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            displayLog()
            Return Nothing
        End Try
    End Function
    Private Function isDNAChar(ByVal c As Char) As Boolean
        Try
            For Each ch As Char In aminoAcidList
                If c = ch Then Return True
            Next
            Return False
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show(ex.toString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            displayLog()
            Return False
        End Try
    End Function
    Public Sub setScoringMatrix(ByRef b As Double(,))
        Try
            For i As Integer = 0 To b.GetUpperBound(0)
                For j As Integer = 0 To b.GetUpperBound(1)
                    currentScoringMatrix(i, j) = b(i, j)
                Next
            Next
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show(ex.toString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            displayLog()
        End Try
    End Sub
    Public Sub setLastCustomMatrix(ByRef b As Double(,))
        Try
            For i As Integer = 0 To b.GetUpperBound(0)
                For j As Integer = 0 To b.GetUpperBound(1)
                    lastCustomMatrix(i, j) = b(i, j)
                Next
            Next
            unsavedMatrix = True
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show(ex.toString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            displayLog()
        End Try
    End Sub
    Private Function getPAM(ByVal n As Integer) As Double(,)
        Try
            Dim m As Double(,) = matrixPower(n - 1, PAM1)
            Dim currentMatrixMin As Double = 2
            Dim multFactor As Integer = 1
            Do
                currentMatrixMin = 2
                For i As Integer = 0 To m.GetUpperBound(0)
                    For j As Integer = 0 To m.GetUpperBound(1)
                        m(i, j) *= multFactor
                        If m(i, j) < currentMatrixMin AndAlso m(i, j) <> 0 Then
                            currentMatrixMin = m(i, j)
                        End If
                    Next
                Next
                multFactor = 10
            Loop While currentMatrixMin <= 0.1
            Return m
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show(ex.toString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            displayLog()
            Return Nothing
        End Try
    End Function
    Private Function matrixPower(ByVal p As Integer, m As Double(,)) As Double(,)
        Try
            Dim returnMatrix(m.GetUpperBound(0), m.GetUpperBound(1)) As Double

            'copy matrix into return matrix
            For i As Integer = 0 To returnMatrix.GetUpperBound(0)
                For j As Integer = 0 To returnMatrix.GetUpperBound(1)
                    returnMatrix(i, j) = m(i, j)
                Next
            Next

            For l As Integer = 0 To p - 1
                Dim resultMatrix(m.GetUpperBound(0), m.GetUpperBound(1)) As Double
                'copy matrix into result matrix
                For i As Integer = 0 To resultMatrix.GetUpperBound(0)
                    For j As Integer = 0 To resultMatrix.GetUpperBound(1)
                        resultMatrix(i, j) = returnMatrix(i, j)
                    Next
                Next

                'multiply result matrix by m and store in result matrix
                For i As Integer = 0 To resultMatrix.GetUpperBound(0)
                    For j As Integer = 0 To resultMatrix.GetUpperBound(1)
                        Dim result As Double = 0
                        'loop through the result matrix row i
                        'multiply cell i,j by cell m j,i
                        For k As Integer = 0 To resultMatrix.GetUpperBound(0)
                            result += resultMatrix(i, k) * m(k, j)
                        Next
                        returnMatrix(i, j) = result
                    Next
                Next
            Next
            Return returnMatrix
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show(ex.toString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            displayLog()
            Return Nothing
        End Try
    End Function
    Private Function smithWaterman(sequence1 As String, sequence2 As String,
                                   scoringMatrix As Double(,), gaptype As GAP_TYPE,
                                   gapScoringScheme As Double, suboptimalScoreThreshold As Double,
                                   isEValue As Boolean, ignoreIntersections As Boolean,
                                   Optional gapScoringScheme2 As Double = 0.0) As Result
        Try
            'log time
            Dim beginTime As Long = DateTime.Now.Ticks

            'create matrices
            Dim hMatrix(sequence1.Length, sequence2.Length) As Double
            Dim tMatrix(sequence1.Length, sequence2.Length) As Integer
            Dim gmatrix(sequence1.Length, sequence2.Length) As Integer

            Dim listHMatrix As List(Of Double(,)) = New List(Of Double(,))
            Dim listTMatrix As List(Of Integer(,)) = New List(Of Integer(,))
            Dim listGMatrix As List(Of Integer(,)) = New List(Of Integer(,))

            ReDim alignmentContainsPartialPathMatrix(sequence1.Length, sequence2.Length)

            'initialize matrices
            For i As Integer = 0 To hMatrix.GetUpperBound(0)
                For j As Integer = 0 To hMatrix.GetUpperBound(1)
                    'set matrices
                    If i = 0 AndAlso j = 0 Then
                        hMatrix(i, j) = 0
                        tMatrix(i, j) = -1
                        gmatrix(i, j) = 0
                    ElseIf i = 0 Then
                        'calculate vertical gap penalty
                        Dim vGapPenalty As Double = 0
                        If gaptype = GAP_TYPE.CONSTANT Then
                            vGapPenalty = If(tMatrix(i, j - 1) <> 1, gapScoringScheme, 0)
                        ElseIf gaptype = GAP_TYPE.LINEAR Then
                            vGapPenalty = gapScoringScheme
                        ElseIf gaptype = GAP_TYPE.AFFINE Then
                            vGapPenalty = If(tMatrix(i, j - 1) = 1,
                                (gapScoringScheme2 * If(tMatrix(i, j - 1) = 1, gmatrix(i, j - 1) + 1, 1)),
                                    gapScoringScheme)
                        End If

                        hMatrix(i, j) = hMatrix(i, j - 1) + vGapPenalty
                        tMatrix(i, j) = 1
                        gmatrix(i, j) = j
                    ElseIf j = 0 Then
                        'calculate horizontal gap penalty
                        Dim hGapPenalty As Double = 0
                        If gaptype = GAP_TYPE.CONSTANT Then
                            hGapPenalty = If(tMatrix(i - 1, j) <> 0, gapScoringScheme, 0)
                        ElseIf gaptype = GAP_TYPE.LINEAR Then
                            hGapPenalty = gapScoringScheme
                        ElseIf gaptype = GAP_TYPE.AFFINE Then
                            hGapPenalty = If(tMatrix(i - 1, j) = 0,
                                (gapScoringScheme2 * If(tMatrix(i - 1, j) = 0, gmatrix(i - 1, j) + 1, 1)),
                                    gapScoringScheme)
                        End If
                        hMatrix(i, j) = hMatrix(i - 1, j) + hGapPenalty
                        tMatrix(i, j) = 0
                        gmatrix(i, j) = i
                    End If
                    hMatrix(i, j) = If(My.Settings.AllowNegativeScores, hMatrix(i, j), Math.Max(hMatrix(i, j), 0))
                Next
            Next

            'fill matrix h
            For i As Integer = 1 To hMatrix.GetUpperBound(0)
                For j As Integer = 1 To hMatrix.GetUpperBound(1)
                    Dim similarityScore As Double = getSimilarityScore(CChar(sequence1.Substring(i - 1, 1)),
                                                                        CChar(sequence2.Substring(j - 1, 1)),
                                                                        scoringMatrix)
                    'calculate horizontal gap penalty
                    Dim hGapPenalty As Double = 0
                    If gaptype = GAP_TYPE.CONSTANT Then
                        hGapPenalty = If(tMatrix(i - 1, j) <> 0, gapScoringScheme, 0)
                    ElseIf gaptype = GAP_TYPE.LINEAR Then
                        hGapPenalty = gapScoringScheme
                    ElseIf gaptype = GAP_TYPE.AFFINE Then
                        hGapPenalty = If(tMatrix(i - 1, j) = 0,
                                (gapScoringScheme2 * If(tMatrix(i - 1, j) = 0, gmatrix(i - 1, j) + 1, 1)),
                                    gapScoringScheme)
                    End If

                    'calculate vertical gap penalty
                    Dim vGapPenalty As Double = 0
                    If gaptype = GAP_TYPE.CONSTANT Then
                        vGapPenalty = If(tMatrix(i, j - 1) <> 1, gapScoringScheme, 0)
                    ElseIf gaptype = GAP_TYPE.LINEAR Then
                        vGapPenalty = gapScoringScheme
                    ElseIf gaptype = GAP_TYPE.AFFINE Then
                        vGapPenalty = If(tMatrix(i, j - 1) = 1,
                                (gapScoringScheme2 * If(tMatrix(i, j - 1) = 1, gmatrix(i, j - 1) + 1, 1)),
                                    gapScoringScheme)
                    End If

                    Dim firstValue As Double = If(My.Settings.AllowNegativeScores, Integer.MinValue, 0)
                    Dim secondValue As Double = hMatrix(i - 1, j - 1) + similarityScore
                    Dim thirdValue As Double = hMatrix(i - 1, j) + hGapPenalty
                    Dim fourthValue As Double = hMatrix(i, j - 1) + vGapPenalty
                    If firstValue >= secondValue AndAlso
                        firstValue >= thirdValue AndAlso
                        firstValue >= fourthValue Then
                        hMatrix(i, j) = firstValue
                        'tMatrix(i, j) = -1
                        'if the value is the first value (0) then just use a horizontal arrow
                        tMatrix(i, j) = 0
                        gmatrix(i, j) = If(tMatrix(i - 1, j) = 0, gmatrix(i - 1, j) + 1, 1)
                    ElseIf secondValue >= firstValue AndAlso
                        secondValue >= thirdValue AndAlso
                        secondValue >= fourthValue Then
                        hMatrix(i, j) = secondValue
                        tMatrix(i, j) = 2
                        gmatrix(i, j) = 0
                    ElseIf thirdValue >= secondValue AndAlso
                        thirdValue >= firstValue AndAlso
                        thirdValue >= fourthValue Then
                        hMatrix(i, j) = thirdValue
                        tMatrix(i, j) = 0
                        gmatrix(i, j) = If(tMatrix(i - 1, j) = 0, gmatrix(i - 1, j) + 1, 1)
                    ElseIf fourthValue >= secondValue AndAlso
                        fourthValue >= firstValue AndAlso
                        fourthValue >= thirdValue Then
                        hMatrix(i, j) = fourthValue
                        tMatrix(i, j) = 1
                        gmatrix(i, j) = If(tMatrix(i, j - 1) = 1, gmatrix(i, j - 1) + 1, 1)
                    End If
                Next
            Next

            'find suboptimal sequences
            'get optimal value
            Dim optimalScoreValue As Double = Double.MinValue
            For Each i As Double In hMatrix
                If i > optimalScoreValue Then
                    optimalScoreValue = i
                End If
            Next

            'calculate e value into suboptimal threshold
            Dim suboptimalThresholdValue As Double = If(isEValue, If(My.Settings.AllowNegativeScores,
                                                                     optimalScoreValue - optimalScoreValue * (suboptimalScoreThreshold / 100),
                                                                     Math.Max(optimalScoreValue - optimalScoreValue * (suboptimalScoreThreshold / 100), 0)),
                                                                 suboptimalScoreThreshold)
            Dim traceBackPaths As List(Of List(Of Integer())) = New List(Of List(Of Integer()))
            Dim alignments As List(Of String()) = New List(Of String())
            Dim scores As List(Of Double) = New List(Of Double)

            If ignoreIntersections Then
                'waterman
                Dim copyHMatrix(hMatrix.GetUpperBound(0), hMatrix.GetUpperBound(1)) As Double
                For i As Integer = 0 To hMatrix.GetUpperBound(0)
                    For j As Integer = 0 To hMatrix.GetUpperBound(1)
                        copyHMatrix(i, j) = hMatrix(i, j)
                    Next
                Next
                'sort values from hmatrix by decreasing scores
                Dim decreasingScoreArray(copyHMatrix.Length - 1) As Double
                Dim decreasingScoreLocationArray(copyHMatrix.Length - 1, 2) As Integer
                For i As Integer = 0 To copyHMatrix.Length - 1
                    Dim greatestCurrentValue As Double = Double.MinValue
                    Dim greatestLocX As Integer = -1
                    Dim greatestLocY As Integer = -1
                    For j As Integer = 0 To copyHMatrix.GetUpperBound(0)
                        For k As Integer = 0 To copyHMatrix.GetUpperBound(1)
                            If greatestCurrentValue < copyHMatrix(j, k) Then
                                greatestCurrentValue = copyHMatrix(j, k)
                                greatestLocX = j
                                greatestLocY = k
                            End If
                        Next
                    Next
                    decreasingScoreArray(i) = greatestCurrentValue
                    copyHMatrix(greatestLocX, greatestLocY) = Double.MinValue
                    decreasingScoreLocationArray(i, 0) = greatestLocX
                    decreasingScoreLocationArray(i, 1) = greatestLocY
                Next

                'go in order of decreasing scores
                'for each one, use location to calculate traceback
                For i As Integer = 0 To decreasingScoreArray.Length - 1
                    'check to make sure score > optimal score threshold
                    If decreasingScoreArray(i) >= suboptimalThresholdValue Then
                        'set score
                        scores.Add(decreasingScoreArray(i))
                        traceBackPaths.Add(New List(Of Integer()))
                        Dim thisAlignment(2) As String
                        thisAlignment(0) = String.Empty
                        thisAlignment(1) = String.Empty
                        thisAlignment(2) = String.Empty

                        'find traceback path and ith optimal alignment
                        Dim currentPosition As Integer() = {decreasingScoreLocationArray(i, 0), decreasingScoreLocationArray(i, 1)}
                        traceBackPaths.Item(traceBackPaths.Count - 1).Add(currentPosition)

                        While hMatrix(currentPosition(0), currentPosition(1)) > 0 AndAlso (currentPosition(0) <> 0 OrElse currentPosition(1) <> 0)
                            If tMatrix(currentPosition(0), currentPosition(1)) = 0 Then
                                thisAlignment(0) &= sequence1.Substring(currentPosition(0) - 1, 1)
                                thisAlignment(1) &= " "
                                thisAlignment(2) &= "_"
                                currentPosition = {currentPosition(0) - 1, currentPosition(1)}
                            ElseIf tMatrix(currentPosition(0), currentPosition(1)) = 1 Then
                                thisAlignment(0) &= "_"
                                thisAlignment(1) &= " "
                                thisAlignment(2) &= sequence2.Substring(currentPosition(1) - 1, 1)
                                currentPosition = {currentPosition(0), currentPosition(1) - 1}
                            ElseIf tMatrix(currentPosition(0), currentPosition(1)) = 2 Then
                                thisAlignment(0) &= sequence1.Substring(currentPosition(0) - 1, 1)
                                thisAlignment(2) &= sequence2.Substring(currentPosition(1) - 1, 1)
                                thisAlignment(1) &= "|"
                                currentPosition = {currentPosition(0) - 1, currentPosition(1) - 1}
                            End If
                            traceBackPaths(traceBackPaths.Count - 1).Add(currentPosition)
                        End While
                        If thisAlignment(0).Length < 1 Then
                            traceBackPaths.RemoveAt(traceBackPaths.Count - 1)
                            scores.RemoveAt(scores.Count - 1)
                        Else
                            traceBackPaths(traceBackPaths.Count - 1).RemoveAt(traceBackPaths(traceBackPaths.Count - 1).Count - 1)
                            thisAlignment(0) = StrReverse(thisAlignment(0))
                            thisAlignment(1) = StrReverse(thisAlignment(1))
                            thisAlignment(2) = StrReverse(thisAlignment(2))
                            traceBackPaths(traceBackPaths.Count - 1).Reverse()
                            alignments.Add(thisAlignment)
                            listHMatrix.Add(hMatrix)
                            listGMatrix.Add(gmatrix)
                            listTMatrix.Add(tMatrix)
                        End If
                    Else
                        Exit For
                    End If
                Next
            Else
                'waterman-eggert
                Dim copyHMatrix(hMatrix.GetUpperBound(0), hMatrix.GetUpperBound(1)) As Double
                Dim copyGMatrix(gmatrix.GetUpperBound(0), gmatrix.GetUpperBound(1)) As Integer
                Dim copyTMatrix(tMatrix.GetUpperBound(0), tMatrix.GetUpperBound(1)) As Integer
                Dim mustStayZero(tMatrix.GetUpperBound(0), tMatrix.GetUpperBound(1)) As Boolean
                For i As Integer = 0 To hMatrix.GetUpperBound(0)
                    For j As Integer = 0 To hMatrix.GetUpperBound(1)
                        copyHMatrix(i, j) = hMatrix(i, j)
                        copyGMatrix(i, j) = gmatrix(i, j)
                        copyTMatrix(i, j) = tMatrix(i, j)
                    Next
                Next
                Dim numOfIterations As Integer = 0
                Dim greatestCurrentValue As Double = Double.MaxValue
                While greatestCurrentValue >= suboptimalThresholdValue AndAlso
                    numOfIterations < copyHMatrix.Length
                    numOfIterations += 1
                    'find greatest score in copyHMatrix
                    greatestCurrentValue = Double.MinValue
                    Dim greatestLocX As Integer = -1
                    Dim greatestLocY As Integer = -1
                    For j As Integer = 0 To copyHMatrix.GetUpperBound(0)
                        For k As Integer = 0 To copyHMatrix.GetUpperBound(1)
                            If greatestCurrentValue < copyHMatrix(j, k) Then
                                greatestCurrentValue = copyHMatrix(j, k)
                                greatestLocX = j
                                greatestLocY = k
                            End If
                        Next
                    Next
                    'use location to calculate traceback
                    'check to make sure score > optimal score threshold
                    If greatestCurrentValue >= suboptimalThresholdValue Then
                        traceBackPaths.Add(New List(Of Integer()))
                        Dim thisAlignment(2) As String
                        thisAlignment(0) = String.Empty
                        thisAlignment(1) = String.Empty
                        thisAlignment(2) = String.Empty

                        'find traceback path and ith optimal alignment
                        Dim currentPosition As Integer() = {greatestLocX, greatestLocY}
                        traceBackPaths.Item(traceBackPaths.Count - 1).Add(currentPosition)

                        While copyHMatrix(currentPosition(0), currentPosition(1)) > 0 AndAlso
                            (currentPosition(0) <> 0 OrElse currentPosition(1) <> 0)
                            If copyTMatrix(currentPosition(0), currentPosition(1)) = 0 Then
                                thisAlignment(0) &= sequence1.Substring(currentPosition(0) - 1, 1)
                                thisAlignment(1) &= " "
                                thisAlignment(2) &= "_"
                                currentPosition = {currentPosition(0) - 1, currentPosition(1)}
                            ElseIf copyTMatrix(currentPosition(0), currentPosition(1)) = 1 Then
                                thisAlignment(0) &= "_"
                                thisAlignment(1) &= " "
                                thisAlignment(2) &= sequence2.Substring(currentPosition(1) - 1, 1)
                                currentPosition = {currentPosition(0), currentPosition(1) - 1}
                            ElseIf copyTMatrix(currentPosition(0), currentPosition(1)) = 2 Then
                                thisAlignment(0) &= sequence1.Substring(currentPosition(0) - 1, 1)
                                thisAlignment(2) &= sequence2.Substring(currentPosition(1) - 1, 1)
                                thisAlignment(1) &= "|"
                                currentPosition = {currentPosition(0) - 1, currentPosition(1) - 1}
                            End If
                            traceBackPaths(traceBackPaths.Count - 1).Add(currentPosition)
                        End While
                        If thisAlignment(0).Length < 1 Then
                            traceBackPaths.RemoveAt(traceBackPaths.Count - 1)
                        Else
                            'remove last traceback element
                            traceBackPaths(traceBackPaths.Count - 1).RemoveAt(traceBackPaths(traceBackPaths.Count - 1).Count - 1)
                            thisAlignment(0) = StrReverse(thisAlignment(0))
                            thisAlignment(1) = StrReverse(thisAlignment(1))
                            thisAlignment(2) = StrReverse(thisAlignment(2))
                            alignments.Add(thisAlignment)
                            scores.Add(greatestCurrentValue)
                            Dim newHMatrix(copyHMatrix.GetUpperBound(0), copyHMatrix.GetUpperBound(1)) As Double
                            For i As Integer = 0 To copyHMatrix.GetUpperBound(0)
                                For j As Integer = 0 To copyHMatrix.GetUpperBound(1)
                                    newHMatrix(i, j) = copyHMatrix(i, j)
                                Next
                            Next
                            listHMatrix.Add(newHMatrix)
                            Dim newGMatrix(copyGMatrix.GetUpperBound(0), copyGMatrix.GetUpperBound(1)) As Integer
                            For i As Integer = 0 To copyGMatrix.GetUpperBound(0)
                                For j As Integer = 0 To copyGMatrix.GetUpperBound(1)
                                    newGMatrix(i, j) = copyGMatrix(i, j)
                                Next
                            Next
                            listGMatrix.Add(newGMatrix)
                            Dim newTMatrix(copyTMatrix.GetUpperBound(0), copyTMatrix.GetUpperBound(1)) As Integer
                            For i As Integer = 0 To copyTMatrix.GetUpperBound(0)
                                For j As Integer = 0 To copyTMatrix.GetUpperBound(1)
                                    newTMatrix(i, j) = copyTMatrix(i, j)
                                Next
                            Next
                            listTMatrix.Add(newTMatrix)
                        End If
                    End If

                    'reverse traceback to start at upper left
                    Dim resetTraceback As List(Of Integer()) = traceBackPaths.Item(traceBackPaths.Count - 1)
                    resetTraceback.Reverse()
                    'first add each to the values zero matrix
                    For Each intArr As Integer() In resetTraceback
                        'start at index directly below this cell
                        Dim currentCell As Integer() = {intArr(0), intArr(1)}
                        copyHMatrix(currentCell(0), currentCell(1)) = 0
                        mustStayZero(currentCell(0), currentCell(1)) = True


                        'update value to the right
                        If currentCell(0) < copyHMatrix.GetUpperBound(0) Then
                            changeGridRecursive(sequence1, sequence2, scoringMatrix, gaptype, gapScoringScheme,
                                                gapScoringScheme2, copyTMatrix,
                                                copyGMatrix, copyHMatrix, {currentCell(0) + 1, currentCell(1)},
                                                mustStayZero)
                        End If
                        'update value bottom
                        If currentCell(1) < copyHMatrix.GetUpperBound(1) Then
                            changeGridRecursive(sequence1, sequence2, scoringMatrix, gaptype, gapScoringScheme,
                                                gapScoringScheme2, copyTMatrix,
                                                copyGMatrix, copyHMatrix, {currentCell(0), currentCell(1) + 1},
                                                mustStayZero)
                        End If
                        'update value diagonal bottom-right
                        If currentCell(1) < copyHMatrix.GetUpperBound(1) AndAlso
                            currentCell(0) < copyHMatrix.GetUpperBound(0) Then
                            changeGridRecursive(sequence1, sequence2, scoringMatrix, gaptype, gapScoringScheme,
                                                gapScoringScheme2, copyTMatrix,
                                                copyGMatrix, copyHMatrix, {currentCell(0) + 1, currentCell(1) + 1},
                                                mustStayZero)
                        End If
                    Next
                End While
            End If
            'loop to calculate partial path matrix
            If traceBackPaths IsNot Nothing Then
                For Each alignment As List(Of Integer()) In traceBackPaths
                    For Each intArr As Integer() In alignment
                        alignmentContainsPartialPathMatrix(intArr(0), intArr(1)) = True
                    Next
                Next
            End If

            'log finish time
            Dim time As Long = DateTime.Now.Ticks - beginTime
            Return New Result(sequence1, sequence2, listHMatrix, listTMatrix, listGMatrix, traceBackPaths,
                              alignments, scores, time, suboptimalThresholdValue, isEValue)
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            If TypeOf ex Is System.OutOfMemoryException Then
                Dim errorString As String = "You do not have enough memory to perform that calculation." &
                    Environment.NewLine &
                    If(ignoreIntersections, "Decrease the lengths of your input and try again.",
                       "Turn on ""Ignore Intersections"" or decrease the lengths of your" & Environment.NewLine &
                       "input and try again.")
                MessageBox.Show(errorString, "Out of Memory Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(ex.toString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            displayLog()
            Return Nothing
        End Try
    End Function
    Private Sub changeGridRecursive(sequence1 As String, sequence2 As String, scoringMatrix As Double(,),
                                    gapType As GAP_TYPE, gapscoringscheme As Double,
                                    gapscoringscheme2 As Double, copyTMatrix As Integer(,),
                                    copyGMatrix As Integer(,), copyHMatrix As Double(,),
                                    currentCell As Integer(), mustStayZero As Boolean(,))
        Dim originalValue As Double = copyHMatrix(currentCell(0), currentCell(1))
        Try
            Dim similarityScore As Double = getSimilarityScore(CChar(sequence1.Substring(currentCell(0) - 1, 1)),
                                                                                CChar(sequence2.Substring(currentCell(1) - 1, 1)),
                                                                                scoringMatrix)

            'calculate horizontal gap penalty
            Dim hGapPenalty As Double = 0
            If gapType = GAP_TYPE.CONSTANT Then
                hGapPenalty = If(copyTMatrix(currentCell(0) - 1, currentCell(1)) <> 0,
                                 gapscoringscheme, 0)
            ElseIf gapType = GAP_TYPE.LINEAR Then
                hGapPenalty = gapscoringscheme
            ElseIf gapType = GAP_TYPE.AFFINE Then
                hGapPenalty = If(copyTMatrix(currentCell(0) - 1, currentCell(1)) = 0,
                                (gapscoringscheme2 * If(copyTMatrix(
                                                        currentCell(0) - 1, currentCell(1)) = 0,
                                                        copyGMatrix(currentCell(0) - 1, currentCell(1)) + 1, 1)),
                                    gapscoringscheme)
            End If

            'calculate vertical gap penalty
            Dim vGapPenalty As Double = 0
            If gapType = GAP_TYPE.CONSTANT Then
                vGapPenalty = If(copyTMatrix(currentCell(0), currentCell(1) - 1) <> 1,
                                 gapscoringscheme, 0)
            ElseIf gapType = GAP_TYPE.LINEAR Then
                vGapPenalty = gapscoringscheme
            ElseIf gapType = GAP_TYPE.AFFINE Then
                vGapPenalty = If(copyTMatrix(currentCell(0), currentCell(1) - 1) = 1,
                                (gapscoringscheme2 * If(copyTMatrix(currentCell(0),
                                            currentCell(1) - 1) = 1, copyGMatrix(currentCell(0),
                                                                        currentCell(1) - 1) + 1, 1)),
                                    gapscoringscheme)
            End If

            Dim firstValue As Double = If(My.Settings.AllowNegativeScores, Integer.MinValue, 0)
            Dim secondValue As Double = copyHMatrix(currentCell(0) - 1, currentCell(1) - 1) + similarityScore
            Dim thirdValue As Double = copyHMatrix(currentCell(0) - 1, currentCell(1)) + hGapPenalty
            Dim fourthValue As Double = copyHMatrix(currentCell(0), currentCell(1) - 1) + vGapPenalty
            If firstValue >= secondValue AndAlso
                firstValue >= thirdValue AndAlso
                firstValue >= fourthValue Then
                copyHMatrix(currentCell(0), currentCell(1)) = firstValue
                'copytmatrix(i, j) = -1
                'if the value is the first value (0) then just use a horizontal arrow
                copyTMatrix(currentCell(0), currentCell(1)) = 0
                copyGMatrix(currentCell(0), currentCell(1)) = If(copyTMatrix(currentCell(0) - 1,
                                                                     currentCell(1)) = 0,
                                                                 copyGMatrix(currentCell(0) - 1,
                                                                         currentCell(1)) + 1, 1)
            ElseIf secondValue >= firstValue AndAlso
                secondValue >= thirdValue AndAlso
                secondValue >= fourthValue Then
                copyHMatrix(currentCell(0), currentCell(1)) = secondValue
                copyTMatrix(currentCell(0), currentCell(1)) = 2
                copyGMatrix(currentCell(0), currentCell(1)) = 0
            ElseIf thirdValue >= secondValue AndAlso
                thirdValue >= firstValue AndAlso
                thirdValue >= fourthValue Then
                copyHMatrix(currentCell(0), currentCell(1)) = thirdValue
                copyTMatrix(currentCell(0), currentCell(1)) = 0
                copyGMatrix(currentCell(0), currentCell(1)) = If(copyTMatrix(currentCell(0) - 1,
                                                                     currentCell(1)) = 0,
                                                                 copyGMatrix(currentCell(0) - 1,
                                                                         currentCell(1)) + 1, 1)
            ElseIf fourthValue >= secondValue AndAlso
                fourthValue >= firstValue AndAlso
                fourthValue >= thirdValue Then
                copyHMatrix(currentCell(0), currentCell(1)) = fourthValue
                copyTMatrix(currentCell(0), currentCell(1)) = 1
                copyGMatrix(currentCell(0), currentCell(1)) = If(copyTMatrix(currentCell(0), currentCell(1) - 1) = 1,
                                                             copyGMatrix(currentCell(0), currentCell(1) - 1) + 1, 1)
            End If
            If mustStayZero(currentCell(0), currentCell(1)) Then
                copyHMatrix(currentCell(0), currentCell(1)) = 0
            End If
            If originalValue <> copyHMatrix(currentCell(0), currentCell(1)) Then
                'recursive call
                'cell right
                If currentCell(0) < copyHMatrix.GetUpperBound(0) Then
                    changeGridRecursive(sequence1, sequence2, scoringMatrix, gapType, gapscoringscheme,
                                        gapscoringscheme2, copyTMatrix,
                                        copyGMatrix, copyHMatrix, {currentCell(0) + 1, currentCell(1)},
                                        mustStayZero)
                End If
                'cell below
                If currentCell(1) < copyHMatrix.GetUpperBound(1) Then
                    changeGridRecursive(sequence1, sequence2, scoringMatrix, gapType, gapscoringscheme,
                                        gapscoringscheme2, copyTMatrix,
                                        copyGMatrix, copyHMatrix, {currentCell(0), currentCell(1) + 1},
                                        mustStayZero)
                End If
                'cell diagonal below-right
                If currentCell(0) < copyHMatrix.GetUpperBound(0) AndAlso
                    currentCell(1) < copyHMatrix.GetUpperBound(1) Then
                    changeGridRecursive(sequence1, sequence2, scoringMatrix, gapType, gapscoringscheme,
                                        gapscoringscheme2, copyTMatrix,
                                        copyGMatrix, copyHMatrix, {currentCell(0) + 1, currentCell(1) + 1},
                                        mustStayZero)
                End If
            End If
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show(ex.toString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            displayLog()
        End Try
    End Sub
    Private Function getSimilarityScore(a As Char, b As Char, scoringMatrix As Double(,)) As Double
        Try
            Dim rowIndex As Integer = -1
            Dim columnindex As Integer = -1
            For i As Integer = 0 To aminoAcidList.Length - 1
                If aminoAcidList(i) = a Then
                    rowIndex = i
                End If
                If aminoAcidList(i) = b Then
                    columnindex = i
                End If
            Next
            Return scoringMatrix(rowIndex, columnindex)
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show(ex.toString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            displayLog()
            Return Nothing
        End Try
    End Function
    Private Sub createSequencePanel(resultsSequencePanel As Panel, nameOfLabel As String, seq1Char As String,
                                    seq2Char As String, numberUpper As Integer, numberLower As Integer,
                                    x As Integer, y As Integer, scoreAtPoint As Double, Optional size As Integer = 12)
        Try
            Dim overridingColor As Color = Nothing
            If My.Settings.SequenceDensityColors Then
                If My.Settings.SimpleSequenceLineView Then
                    overridingColor = System.Drawing.Color.FromArgb(255,
                                                                    Math.Min(255, CInt(Math.Floor(SystemColors.Control.R + Math.Abs(Color.Orange.R - SystemColors.Control.R) * scoreAtPoint))),
                                                                    Math.Min(255, CInt(Math.Floor(SystemColors.Control.G - Math.Abs(SystemColors.Control.G - Color.Orange.G) * scoreAtPoint))),
                                                                    Math.Min(255, CInt(Math.Floor(SystemColors.Control.B - Math.Abs(SystemColors.Control.B - Color.Orange.B) * scoreAtPoint))))

                Else
                    overridingColor = System.Drawing.Color.FromArgb(255,
                                                                    Math.Min(255, CInt(Math.Floor(255 - (255 - Color.Orange.R) * scoreAtPoint))),
                                                                    Math.Min(255, CInt(Math.Floor(255 - (255 - Color.Orange.G) * scoreAtPoint))),
                                                                    Math.Min(255, CInt(Math.Floor(255 - (255 - Color.Orange.B) * scoreAtPoint))))
                End If
            End If
            Dim mismatchcolor As Color = My.Settings.GraphicResultsMatchColor
            If My.Settings.DimMismatches Then
                mismatchcolor = Color.FromArgb(My.Settings.GraphicResultsMatchColor.A,
                                                            Math.Min(255, CInt(Math.Floor(My.Settings.GraphicResultsMatchColor.R * 1.5))),
                                                            Math.Min(255, CInt(Math.Floor(My.Settings.GraphicResultsMatchColor.G * 1.5))),
                                                            Math.Min(255, CInt(Math.Floor(My.Settings.GraphicResultsMatchColor.B * 1.5))))
            End If
            Dim alignmentT As ALIGNMENT_TYPE
            If seq1Char = "_" Then
                alignmentT = ALIGNMENT_TYPE.GAP_IN_SEQUENCE1
            ElseIf seq2Char = "_" Then
                alignmentT = ALIGNMENT_TYPE.GAP_IN_SEQUENCE2
            ElseIf seq1Char = seq2Char Then
                alignmentT = ALIGNMENT_TYPE.MATCH
            Else
                alignmentT = ALIGNMENT_TYPE.MISMATCH
            End If
            Dim numberUpperString As String = If(numberUpper = -1 OrElse numberUpper > 999,
                                                 String.Empty, numberUpper.ToString)
            Dim numberLowerString As String = If(numberLower = -1 OrElse numberLower > 999,
                                                 String.Empty, numberLower.ToString)
            Dim panelAlreadyExists As Boolean = False
            Dim p As Panel = Nothing
            For Each c As Control In resultsSequencePanel.Controls
                If c.Name = nameOfLabel & "_panel" Then
                    panelAlreadyExists = True
                    p = CType(c, Panel)
                    Exit For
                End If
            Next
            If panelAlreadyExists Then
                p.BackColor = SystemColors.Control
                'display main label
                Dim l As Label = Nothing
                For Each c As Control In p.Controls
                    If c.Name = nameOfLabel & "_1" Then
                        l = CType(c, Label)
                    End If
                Next
                l.Text = seq1Char
                l.BackColor = If(My.Settings.SimpleSequenceLineView, SystemColors.Control,
                                 If(My.Settings.SequenceDensityColors, overridingColor,
                                 If(alignmentT = ALIGNMENT_TYPE.MATCH, My.Settings.GraphicResultsMatchColor,
                                 If(alignmentT = ALIGNMENT_TYPE.MISMATCH, mismatchcolor,
                                    If(alignmentT = ALIGNMENT_TYPE.GAP_IN_SEQUENCE1, My.Settings.GraphicResultsSeq1GapColor,
                                       If(alignmentT = ALIGNMENT_TYPE.GAP_IN_SEQUENCE2,
                                          My.Settings.GraphicResultsSeq2GapColor, l.BackColor))))))
                'line label
                Dim lineL As Label = Nothing
                For Each c As Control In p.Controls
                    If c.Name = nameOfLabel & "_lineLabel" Then
                        lineL = CType(c, Label)
                    End If
                Next
                lineL.Width = If(My.Settings.SimpleSequenceLineView, 21, 20)
                lineL.BackColor = If(My.Settings.SequenceDensityColors, overridingColor,
                                  If(alignmentT = ALIGNMENT_TYPE.MATCH, My.Settings.GraphicResultsMatchColor,
                                 If(alignmentT = ALIGNMENT_TYPE.MISMATCH, mismatchcolor,
                                    If(alignmentT = ALIGNMENT_TYPE.GAP_IN_SEQUENCE1, My.Settings.GraphicResultsSeq1GapColor,
                                       If(alignmentT = ALIGNMENT_TYPE.GAP_IN_SEQUENCE2,
                                          My.Settings.GraphicResultsSeq2GapColor, lineL.BackColor)))))

                Dim l2 As Label = Nothing
                For Each c As Control In p.Controls
                    If c.Name = nameOfLabel & "_2" Then
                        l2 = CType(c, Label)
                    End If
                Next
                l2.Text = seq2Char
                l2.BackColor = If(My.Settings.SimpleSequenceLineView, SystemColors.Control,
                                  If(My.Settings.SequenceDensityColors, overridingColor,
                                  If(alignmentT = ALIGNMENT_TYPE.MATCH, My.Settings.GraphicResultsMatchColor,
                                 If(alignmentT = ALIGNMENT_TYPE.MISMATCH, mismatchcolor,
                                    If(alignmentT = ALIGNMENT_TYPE.GAP_IN_SEQUENCE1, My.Settings.GraphicResultsSeq1GapColor,
                                       If(alignmentT = ALIGNMENT_TYPE.GAP_IN_SEQUENCE2,
                                          My.Settings.GraphicResultsSeq2GapColor, l2.BackColor))))))


                'display upper label
                Dim ul As Label = Nothing
                For Each c As Control In p.Controls
                    If c.Name = nameOfLabel & "_upper" Then
                        ul = CType(c, Label)
                    End If
                Next
                ul.Text = numberUpperString

                'display lower label
                Dim ll As Label = Nothing
                For Each c As Control In p.Controls
                    If c.Name = nameOfLabel & "_lower" Then
                        ll = CType(c, Label)
                    End If
                Next
                ll.Text = numberLowerString


                'display border label
                Dim bl As Label = Nothing
                For Each c As Control In p.Controls
                    If c.Name = nameOfLabel & "_border" Then
                        bl = CType(c, Label)
                    End If
                Next
                bl.BorderStyle = If(My.Settings.SimpleSequenceLineView, BorderStyle.None, BorderStyle.FixedSingle)
            Else
                p = New Panel()
                p.Name = nameOfLabel & "_panel"
                p.Location = New System.Drawing.Point(x, y)
                p.Parent = resultsSequencePanel
                p.BorderStyle = BorderStyle.None
                p.AutoSize = False
                p.Height = 70
                p.Width = 22
                p.BackColor = SystemColors.Control

                'display main label
                Dim l As Label = New Label()
                l.Name = nameOfLabel & "_1"
                l.Text = seq1Char
                l.Location = New System.Drawing.Point(1, 11)
                l.Parent = p
                l.BorderStyle = BorderStyle.None
                l.AutoSize = False
                l.BackColor = If(My.Settings.SimpleSequenceLineView, SystemColors.Control,
                                 If(My.Settings.SequenceDensityColors, overridingColor,
                                 If(alignmentT = ALIGNMENT_TYPE.MATCH, My.Settings.GraphicResultsMatchColor,
                                 If(alignmentT = ALIGNMENT_TYPE.MISMATCH, mismatchcolor,
                                    If(alignmentT = ALIGNMENT_TYPE.GAP_IN_SEQUENCE1, My.Settings.GraphicResultsSeq1GapColor,
                                       If(alignmentT = ALIGNMENT_TYPE.GAP_IN_SEQUENCE2,
                                          My.Settings.GraphicResultsSeq2GapColor, l.BackColor))))))
                l.Font = New Font("Courier New", size, FontStyle.Regular)
                l.Height = 21
                l.Width = 20
                l.TextAlign = ContentAlignment.MiddleCenter

                'display line label
                Dim lineL As Label = New Label()
                lineL.Name = nameOfLabel & "_lineLabel"
                lineL.Location = New System.Drawing.Point(1, 32)
                lineL.Parent = p
                lineL.AutoSize = False
                lineL.BackColor = If(My.Settings.SequenceDensityColors, overridingColor,
                                  If(alignmentT = ALIGNMENT_TYPE.MATCH, My.Settings.GraphicResultsMatchColor,
                                 If(alignmentT = ALIGNMENT_TYPE.MISMATCH, mismatchcolor,
                                    If(alignmentT = ALIGNMENT_TYPE.GAP_IN_SEQUENCE1, My.Settings.GraphicResultsSeq1GapColor,
                                       If(alignmentT = ALIGNMENT_TYPE.GAP_IN_SEQUENCE2,
                                          My.Settings.GraphicResultsSeq2GapColor, lineL.BackColor)))))
                lineL.Height = 5
                lineL.Width = If(My.Settings.SimpleSequenceLineView, 21, 20)

                'display main label2
                Dim l2 As Label = New Label()
                l2.Name = nameOfLabel & "_2"
                l2.Text = seq2Char
                l2.Location = New System.Drawing.Point(1, 37)
                l2.Parent = p
                l2.BorderStyle = BorderStyle.None
                l2.AutoSize = False
                l2.BackColor = If(My.Settings.SimpleSequenceLineView, SystemColors.Control,
                                  If(My.Settings.SequenceDensityColors, overridingColor,
                                  If(alignmentT = ALIGNMENT_TYPE.MATCH, My.Settings.GraphicResultsMatchColor,
                                 If(alignmentT = ALIGNMENT_TYPE.MISMATCH, mismatchcolor,
                                    If(alignmentT = ALIGNMENT_TYPE.GAP_IN_SEQUENCE1, My.Settings.GraphicResultsSeq1GapColor,
                                       If(alignmentT = ALIGNMENT_TYPE.GAP_IN_SEQUENCE2,
                                          My.Settings.GraphicResultsSeq2GapColor, l2.BackColor))))))
                l2.Font = New Font("Courier New", size, FontStyle.Regular)
                l2.Height = 22
                l2.Width = 20
                l2.TextAlign = ContentAlignment.MiddleCenter

                'display border label
                Dim bl As Label = New Label()
                bl.Name = nameOfLabel & "_border"
                bl.Location = New System.Drawing.Point(0, 10)
                bl.Parent = p
                bl.BorderStyle = If(My.Settings.SimpleSequenceLineView, BorderStyle.None, BorderStyle.FixedSingle)
                bl.AutoSize = False
                bl.Height = 50
                bl.Width = 22

                'display upper label
                Dim ul As Label = New Label()
                ul.Name = nameOfLabel & "_upper"
                ul.Text = numberUpperString
                ul.Location = New System.Drawing.Point(2, 0)
                ul.Parent = p
                ul.BorderStyle = BorderStyle.None
                ul.AutoSize = False
                ul.BackColor = SystemColors.Control
                ul.Font = New Font("Courier New", 6, FontStyle.Regular)
                ul.Height = 10
                ul.Width = 20
                ul.TextAlign = ContentAlignment.TopCenter

                'display lower label
                Dim ll As Label = New Label()
                ll.Name = nameOfLabel & "_lower"
                ll.Text = numberLowerString
                ll.Location = New System.Drawing.Point(2, 62)
                ll.Parent = p
                ll.BorderStyle = BorderStyle.None
                ll.AutoSize = False
                ll.BackColor = SystemColors.Control
                ll.Font = New Font("Courier New", 6, FontStyle.Regular)
                ll.Height = 8
                ll.Width = 20
                ll.TextAlign = ContentAlignment.TopCenter
            End If
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show(ex.toString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            displayLog()
        End Try
    End Sub
    Private Sub displayAlignment(number As Integer)
        Try
            If currentResult Is Nothing OrElse currentResult.getAlignments.Count - 1 < number OrElse
                number < 0 Then
                If resultsGB.Controls.Contains(resultsPanelsArray(0)) AndAlso
                    resultsPanelsArray(0) IsNot Nothing Then
                    resultsGB.Controls.Remove(resultsPanelsArray(0))
                End If
                If resultsGB.Controls.Contains(resultsPanelsArray(1)) AndAlso
                    resultsPanelsArray(1) IsNot Nothing Then
                    resultsGB.Controls.Remove(resultsPanelsArray(1))
                End If
                If resultsGB.Controls.Contains(resultsPanelsArray(2)) AndAlso
                    resultsPanelsArray(2) IsNot Nothing Then
                    resultsGB.Controls.Remove(resultsPanelsArray(2))
                End If
                If resultsGB.Controls.Contains(resultsPanelsArray(3)) AndAlso
                    resultsPanelsArray(3) IsNot Nothing Then
                    resultsGB.Controls.Remove(resultsPanelsArray(3))
                End If
                If resultsGB.Controls.Contains(resultsPanelsArray(4)) AndAlso
                    resultsPanelsArray(3) IsNot Nothing Then
                    resultsGB.Controls.Remove(resultsPanelsArray(4))
                End If
                compareMultipleAlignmentsToolStripMenuItem.Enabled = False
                orderByLabel.Visible = False
                orderByComboBox.Visible = False
                suboptimalLeftButton.Visible = False
                suboptimalRightButton.Visible = False
                suboptimalFirstButton.Visible = False
                suboptimalLastButton.Visible = False
                matchesGapsDCButton.Visible = False
                gapsOnlyDCButton.Visible = False
                matchesOnlyDCButton.Visible = False
                zoomToActualButton.Enabled = False
                zoomToFitButton.Enabled = False
                ZoomToFitToolStripMenuItem.Enabled = False
                ZoomToActualSizeToolStripMenuItem.Enabled = False
                SaveAlignmentLAVTToolStripMenuItem.Enabled = False
                resultsPanelsArray(0) = Nothing
                resultsPanelsArray(1) = Nothing
                resultsPanelsArray(2) = Nothing
                resultsPanelsArray(3) = Nothing
                resultsPanelsArray(4) = Nothing
                statsPanel = Nothing
                Return
            End If
            If TimeSpan.FromTicks(currentResult.getTime()).TotalSeconds > 1 Then
                Me.Enabled = False
                Me.Refresh()
            End If
            Dim resultsPanel As Panel = resultsPanelsArray(0)
            'low quality grid
            'grid display        
            If currentResult.getAlignments.Count > 0 Then
                If currentResult.getAlignments.Count > 1 Then
                    orderByLabel.Visible = True
                    orderByComboBox.Visible = True
                Else
                    orderByLabel.Visible = False
                    orderByComboBox.Visible = False
                End If
                resultsPanel = If(resultsPanel Is Nothing, New Panel(), resultsPanel)
                resultsPanel.Parent = Nothing
                resultsPanel.Size = New System.Drawing.Size(543, 448)
                resultsPanel.Location = New System.Drawing.Point(2, 55)
                resultsPanel.AutoScroll = True
                resultsPanel.Name = "resultsPanel"

                'show results
                Dim hMatrix As Double(,) = currentResult.getHMatrix().Item(number)
                Dim tMatrix As Integer(,) = currentResult.getTMatrix().Item(number)

                'create a grid and display H and T matrix together
                If resultsPanel.GetChildAtPoint(New System.Drawing.Point(10, 10)) IsNot Nothing Then
                    resultsPanel.Controls.Remove(resultsPanel.GetChildAtPoint(New System.Drawing.Point(10, 10)))
                End If
                Dim grid As DataGridView = New DataGridView
                Dim sizeOfPanels As Integer = Math.Max(If(zoomToActualButton.Checked, 61,
                                                     Math.Min(61, Math.Min(CInt(Math.Floor(grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                              CInt(Math.Floor(grid.Size.Height / currentResult.getSequence2().Length - 1))))), 4)
                grid.Parent = resultsPanel
                grid.Size = New System.Drawing.Size(523, 428)
                grid.Location = New System.Drawing.Point(10, 10)
                grid.Name = "resultsPanelGrid"
                grid.ColumnHeadersHeight = sizeOfPanels
                grid.ColumnHeadersVisible = True
                grid.RowHeadersVisible = True
                grid.RowHeadersWidth = sizeOfPanels
                grid.AllowUserToResizeColumns = False
                grid.AllowUserToResizeRows = False
                grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
                grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                grid.AllowUserToAddRows = False
                grid.AllowUserToDeleteRows = False
                grid.AllowUserToOrderColumns = False
                grid.ReadOnly = True
                Dim style As DataGridViewCellStyle = New DataGridViewCellStyle()
                style.Font = New Font("Courier New", 10, FontStyle.Regular)
                grid.Font = New Font("Courier New", 10, FontStyle.Regular)
                style.BackColor = SystemColors.Control
                style.ForeColor = Color.Black
                style.Alignment = DataGridViewContentAlignment.TopLeft
                style.SelectionBackColor = My.Settings.GraphicResultsSelectionColor
                style.SelectionForeColor = Color.Black
                style.WrapMode = DataGridViewTriState.True
                grid.DefaultCellStyle = style
                grid.ColumnHeadersDefaultCellStyle = style
                grid.RowHeadersDefaultCellStyle = style
                grid.BorderStyle = BorderStyle.FixedSingle
                grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                grid.CellBorderStyle = DataGridViewCellBorderStyle.Single
                grid.BackgroundColor = SystemColors.Control
                grid.GridColor = Color.Black
                AddHandler grid.RowPrePaint, AddressOf grid_RowPrePaint

                'set column count
                grid.ColumnCount = currentResult.getSequence1().Length + 1

                'first create row headers
                grid.Columns(0).HeaderText = "     0       _"
                grid.Columns(0).HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.TopLeft
                grid.Columns(0).Resizable = DataGridViewTriState.False
                grid.Columns(0).Width = sizeOfPanels
                grid.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
                For i As Integer = 1 To grid.ColumnCount - 1
                    grid.Columns(i).HeaderText = "  " & (i).ToString().PadLeft(4) &
                                            "       " &
                                            currentResult.getSequence1()(i - 1)
                    grid.Columns(i).HeaderCell.Style.Alignment =
                        DataGridViewContentAlignment.TopLeft
                    grid.Columns(i).Resizable = DataGridViewTriState.False
                    grid.Columns(i).Width = sizeOfPanels
                    grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Next
                Dim currRow As DataGridViewRow = New DataGridViewRow()
                currRow.Height = sizeOfPanels
                currRow.Resizable = DataGridViewTriState.False
                currRow.HeaderCell.Value = "     0" & Environment.NewLine &
                                            "       " & Environment.NewLine &
                                            "_"
                grid.Rows.Add(currRow)
                For i As Integer = 0 To currentResult.getSequence2().Length - 1
                    currRow = New DataGridViewRow()
                    currRow.Height = sizeOfPanels
                    currRow.Resizable = DataGridViewTriState.False
                    currRow.HeaderCell.Value = "  " & (i + 1).ToString().PadLeft(4) & Environment.NewLine &
                                            "       " & Environment.NewLine &
                                            currentResult.getSequence2()(i)

                    grid.Rows.Add(currRow)
                Next
                'create first row
                'show matrix b
                For i As Integer = 0 To grid.Columns.Count - 1
                    For j As Integer = 0 To grid.Rows.Count - 1
                        If i = 0 AndAlso j = 0 Then
                            grid.Rows(0).Cells(0).Value = "0      " &
                                                                "       " &
                                                                "0"
                        Else
                            Dim gapNumber As Integer = currentResult.getGMatrix().Item(
                                number)(i, j)
                            Dim arrowSymbol As String = If(tMatrix(i, j) = 0, "←", If(tMatrix(i, j) = 1, "↑", "↖"))
                            grid.Rows(j).Cells(i).Value = gapNumber.ToString().PadRight(3) & "  " & arrowSymbol &
                                        "      " &
                                        Math.Round(hMatrix(i, j), 2).ToString().PadLeft(3)
                        End If
                        'is grid in traceback path?
                        Dim containsTBP As Boolean = False
                        For Each arr As Integer() In currentResult.getTraceBackPaths()(number)
                            If arr(0) = i AndAlso arr(1) = j Then
                                containsTBP = True
                            End If
                        Next
                        grid.Rows(j).Cells(i).Style.BackColor = If(containsTBP, My.Settings.GraphicResultsCurrentColor,
                                                       If(tMatrix(i, j) = 0, My.Settings.GraphicResultsSeq2GapColor,
                                                       If(tMatrix(i, j) = 1, My.Settings.GraphicResultsSeq1GapColor,
                                                          If(tMatrix(i, j) = 2, My.Settings.GraphicResultsMatchColor,
                                                             grid.Rows(0).Cells(0).Style.BackColor))))
                    Next
                Next

                currentlyDisplayedAlignment = number
                If currentResult.getAlignments.Count > 1 Then
                    'suboptimal alignments exist
                    suboptimalLeftButton.Visible = True
                    suboptimalRightButton.Visible = True
                    suboptimalFirstButton.Visible = True
                    suboptimalLastButton.Visible = True
                    If currentlyDisplayedAlignment = 0 Then
                        suboptimalLeftButton.Enabled = False
                        suboptimalFirstButton.Enabled = False
                        suboptimalRightButton.Enabled = True
                        suboptimalLastButton.Enabled = True
                    ElseIf currentlyDisplayedAlignment = currentResult.getAlignments.Count - 1 Then
                        suboptimalLeftButton.Enabled = True
                        suboptimalFirstButton.Enabled = True
                        suboptimalRightButton.Enabled = False
                        suboptimalLastButton.Enabled = False
                    Else
                        suboptimalLeftButton.Enabled = True
                        suboptimalFirstButton.Enabled = True
                        suboptimalRightButton.Enabled = True
                        suboptimalLastButton.Enabled = True
                    End If
                Else
                    'no suboptimal alignments exist
                    suboptimalLeftButton.Visible = False
                    suboptimalRightButton.Visible = False
                    suboptimalFirstButton.Visible = False
                    suboptimalLastButton.Visible = False
                End If
                grid.FirstDisplayedScrollingRowIndex = currentResult.getTraceBackPaths()(number).Item(0)(1)
                grid.FirstDisplayedScrollingColumnIndex = currentResult.getTraceBackPaths()(number).Item(0)(0)
            Else
                orderByLabel.Visible = False
                orderByComboBox.Visible = False
            End If

            'display statistical label
            If statResultsGB.HasChildren Then
                statResultsGB.Controls.Remove(statResultsGB.GetChildAtPoint(New System.Drawing.Point(2, 18)))
            End If
            Dim statResultsPanel As Panel = New Panel()
            statResultsPanel.Parent = statResultsGB
            statResultsPanel.Size = New System.Drawing.Size(283, 485)
            statResultsPanel.Location = New System.Drawing.Point(2, 18)
            statResultsPanel.AutoScroll = True
            statResultsPanel.Name = "statResultsPanel"
            statsPanel = statResultsPanel

            Dim l As Label = New Label()
            l.Name = "statisticalResultsLabel"
            If currentResult.getAlignments().Count > 0 Then
                l.Width = Math.Max(254, (currentResult.getAlignments().Item(number)(0).Length * 8) + 20)
                l.Height = 386 + currentResult.getAlignments().Item(number)(0).Length * 17
                l.Text = "Alignment Number: " & Environment.NewLine &
                    number + 1 & " of " & currentResult.getAlignments().Count & Environment.NewLine &
                    Environment.NewLine &
                    "Sequence Alignment: " & Environment.NewLine &
                    currentResult.getAlignments().Item(number)(0) & Environment.NewLine &
                    currentResult.getAlignments().Item(number)(1) & Environment.NewLine &
                    currentResult.getAlignments().Item(number)(2) & Environment.NewLine &
                    Environment.NewLine &
                    "Score:      " & Math.Round(currentResult.getScores().Item(number), 2) & Environment.NewLine &
                    "Length:     " & currentResult.getAlignments().Item(number)(0).Length & Environment.NewLine &
                    "Identity:   " & currentResult.getPercentIdentity(number).ToString("p2") & Environment.NewLine &
                    "Similarity: " & currentResult.getPercentSimilarity(number).ToString("p2") & Environment.NewLine &
                    "Gaps:       " & currentResult.getNumberOfGaps(number) & Environment.NewLine &
                    "Matches:    " & currentResult.getNumberOfMatches(number) & Environment.NewLine &
                    "Mismatches  " & currentResult.getNumberOfMismatches(number) & Environment.NewLine &
                    Environment.NewLine &
                    "Time:       " & TimeSpan.FromTicks(currentResult.getTime()).ToString & Environment.NewLine &
                    "e-Value:    " & currentResult.getEvalues().Item(number) & Environment.NewLine &
                    "Threshold:  " & currentResult.getOptimalThresholdValue & Environment.NewLine &
                    Environment.NewLine &
                    "Traceback:  " & Environment.NewLine & currentResult.getTracebackPathAsString(number)
            Else
                l.Width = 204
                l.Text = "Optimal Alignment: NONE" & Environment.NewLine &
                    "Score: Negative Infinity" & Environment.NewLine &
                    Environment.NewLine &
                    "Number of Suboptimal Alignments: 0 of 0"
            End If
            l.Location = New System.Drawing.Point(10, 10)
            l.Parent = statResultsPanel
            l.BorderStyle = BorderStyle.None
            l.AutoSize = False
            l.Font = New Font("Courier New", 10, FontStyle.Regular)
            l.TextAlign = ContentAlignment.TopLeft

            'sequence display
            Dim resultsSequencePanel As Panel = Nothing
            If currentResult.getAlignments.Count > 0 Then
                If resultsPanelsArray(1) IsNot Nothing Then
                    resultsSequencePanel = resultsPanelsArray(1)
                    Dim deleteCount As Integer = currentResult.getAlignments(number)(0).Length
                    If deleteCount < resultsSequencePanel.Controls.Count Then
                        For i As Integer = 0 To resultsSequencePanel.Controls.Count - 1
                            If i > resultsSequencePanel.Controls.Count - 1 Then Exit For
                            If resultsSequencePanel.Controls.Item(i).Name = "label_" & deleteCount & "_panel" Then
                                resultsSequencePanel.Controls.Remove(resultsSequencePanel.Controls.Item(i))
                                i -= 1
                                deleteCount += 1
                            End If
                        Next
                    End If
                End If
                resultsSequencePanel = If(resultsSequencePanel Is Nothing, New Panel(), resultsSequencePanel)
                resultsSequencePanel.Parent = Nothing
                resultsSequencePanel.Size = New System.Drawing.Size(543, 446)
                resultsSequencePanel.Location = New System.Drawing.Point(2, 56)
                resultsSequencePanel.AutoScroll = True
                resultsSequencePanel.Name = "resultsSequencePanel"
                resultsSequencePanel.AutoScrollPosition = New System.Drawing.Point(0, 0)

                '#################
                '# DRAW SEQUENCE #
                '#################
                Dim numberOfPanelsOnWidth As Integer = 24
                Dim count As Integer = 0
                For column As Integer = 0 To CInt(Math.Ceiling(
                        currentResult.getAlignments(number)(0).Length / numberOfPanelsOnWidth))
                    For row As Integer = 0 To numberOfPanelsOnWidth - 1
                        If currentResult.getAlignments(number)(0).Length - 1 < count Then Exit For
                        Dim displayUpperNumber As Integer = -1
                        Dim displayLowerNumber As Integer = -1
                        If My.Settings.DisplaySequence1Numbers Then
                            Dim charDisplayCount As Integer = 0
                            Dim isGap As Boolean = False
                            For i As Integer = 0 To count
                                If currentResult.getAlignments(number)(0).Substring(i, 1) <> "_" Then
                                    charDisplayCount += 1
                                    isGap = False
                                Else
                                    isGap = True
                                End If
                            Next
                            If charDisplayCount Mod My.Settings.DisplayNumbersEvery = 0 AndAlso Not isGap Then
                                displayUpperNumber = charDisplayCount
                            End If
                        End If
                        If My.Settings.DisplaySequence2Numbers Then
                            Dim charDisplayCount As Integer = 0
                            Dim isGap As Boolean = False
                            For i As Integer = 0 To count
                                If currentResult.getAlignments(number)(2).Substring(i, 1) <> "_" Then
                                    charDisplayCount += 1
                                    isGap = False
                                Else
                                    isGap = True
                                End If
                            Next
                            If charDisplayCount Mod My.Settings.DisplayNumbersEvery = 0 AndAlso Not isGap Then
                                displayLowerNumber = charDisplayCount
                            End If
                        End If
                        createSequencePanel(resultsSequencePanel, "label_" & count,
                                        currentResult.getAlignments(number)(0).Substring(count, 1),
                                        currentResult.getAlignments(number)(2).Substring(count, 1),
                                        displayUpperNumber, displayLowerNumber,
                                        10 + (21 * row), CInt(10 + (69 * column)), currentResult.getColorValueAtPoint(number, count))
                        count += 1
                    Next
                Next

                '#########################
                '# DONE DRAWING SEQUENCE #
                '#########################
                'partial path panel
                Dim resultsPartialPathPanel As Panel = Nothing
                If currentResult.getAlignments.Count > 0 Then
                    If resultsPanelsArray(2) IsNot Nothing Then
                        resultsPartialPathPanel = resultsPanelsArray(2)
                    End If
                    resultsPartialPathPanel = If(resultsPartialPathPanel Is Nothing, New Panel(), resultsPartialPathPanel)
                    resultsPartialPathPanel.Parent = Nothing
                    resultsPartialPathPanel.Size = New System.Drawing.Size(543, 446)
                    resultsPartialPathPanel.Location = New System.Drawing.Point(2, 56)
                    resultsPartialPathPanel.AutoScroll = True
                    resultsPartialPathPanel.Name = "resultsPartialPathPanel"
                    resultsPartialPathPanel.AutoScrollPosition = New System.Drawing.Point(0, 0)


                    If resultsPartialPathPanel.GetChildAtPoint(New System.Drawing.Point(10, 10)) IsNot Nothing Then
                        resultsPartialPathPanel.Controls.Remove(resultsPartialPathPanel.GetChildAtPoint(New System.Drawing.Point(10, 10)))
                    End If
                    Dim grid As DataGridView = New DataGridView
                    grid.Parent = resultsPartialPathPanel
                    grid.Size = New System.Drawing.Size(523, 428)
                    grid.Location = New System.Drawing.Point(10, 10)
                    grid.Name = "resultsPartialPathGrid"
                    Dim sizeOfPanels As Integer = Math.Max(If(zoomToActualButton.Checked, 19,
                                                     Math.Min(19, Math.Min(CInt(Math.Floor(grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                              CInt(Math.Floor(grid.Size.Height / currentResult.getSequence2().Length - 1))))), 4)
                    grid.ColumnHeadersHeight = sizeOfPanels
                    grid.ColumnHeadersVisible = True
                    grid.RowHeadersVisible = True
                    grid.RowHeadersWidth = sizeOfPanels
                    grid.AllowUserToResizeColumns = False
                    grid.AllowUserToResizeRows = False
                    grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
                    grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                    grid.AllowUserToAddRows = False
                    grid.AllowUserToDeleteRows = False
                    grid.AllowUserToOrderColumns = False
                    grid.ReadOnly = True
                    Dim style As DataGridViewCellStyle = New DataGridViewCellStyle()
                    style.Font = New Font("Courier New", 10, FontStyle.Regular)
                    grid.Font = New Font("Courier New", 10, FontStyle.Regular)
                    style.BackColor = Color.White
                    style.ForeColor = Color.Black
                    style.Alignment = DataGridViewContentAlignment.TopLeft
                    style.SelectionBackColor = style.BackColor
                    style.SelectionForeColor = style.ForeColor
                    style.WrapMode = DataGridViewTriState.True
                    grid.DefaultCellStyle = style
                    grid.ColumnHeadersDefaultCellStyle = style
                    grid.RowHeadersDefaultCellStyle = style
                    grid.BorderStyle = BorderStyle.None
                    grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                    grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                    grid.CellBorderStyle = DataGridViewCellBorderStyle.Single
                    grid.BackgroundColor = Color.White
                    grid.GridColor = If(My.Settings.ShowGridLinesPartialPath, Color.LightGray, Color.White)
                    AddHandler grid.RowPrePaint, AddressOf partialPathGrid_RowPrePaint
                    AddHandler grid.CellPainting, AddressOf partialPathGrid_CellPainting

                    'set column count
                    grid.ColumnCount = currentResult.getSequence1().Length + 1

                    'first column header
                    grid.Columns(0).HeaderText = "_"
                    grid.Columns(0).HeaderCell.Style.Alignment =
                         DataGridViewContentAlignment.MiddleCenter
                    grid.Columns(0).Resizable = DataGridViewTriState.False
                    grid.Columns(0).Width = sizeOfPanels
                    grid.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable

                    'first create row headers
                    For i As Integer = 1 To grid.ColumnCount - 1
                        grid.Columns(i).HeaderText = currentResult.getSequence1()(i - 1)
                        grid.Columns(i).HeaderCell.Style.Alignment =
                            DataGridViewContentAlignment.MiddleCenter
                        grid.Columns(i).Resizable = DataGridViewTriState.False
                        grid.Columns(i).Width = sizeOfPanels
                        grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                    Next

                    Dim b As DataGridViewRow = New DataGridViewRow()
                    b.Height = sizeOfPanels
                    b.Resizable = DataGridViewTriState.False
                    b.HeaderCell.Value = "_"
                    grid.Rows.Add(b)

                    For i As Integer = 1 To currentResult.getSequence2().Length
                        Dim currRow As DataGridViewRow = New DataGridViewRow()
                        currRow.Height = sizeOfPanels
                        currRow.Resizable = DataGridViewTriState.False
                        currRow.HeaderCell.Value = currentResult.getSequence2()(i - 1)
                        grid.Rows.Add(currRow)
                    Next
                End If

                'dot plot panel

                Dim resultsDotPlotPanel As Panel = Nothing
                If currentResult.getAlignments.Count > 0 Then
                    If resultsPanelsArray(3) IsNot Nothing Then
                        resultsDotPlotPanel = resultsPanelsArray(3)
                    End If
                    resultsDotPlotPanel = If(resultsDotPlotPanel Is Nothing, New Panel(), resultsDotPlotPanel)
                    resultsDotPlotPanel.Parent = Nothing
                    resultsDotPlotPanel.Size = New System.Drawing.Size(543, 446)
                    resultsDotPlotPanel.Location = New System.Drawing.Point(2, 56)
                    resultsDotPlotPanel.AutoScroll = True
                    resultsDotPlotPanel.Name = "resultsDotPlotPanel"
                    resultsDotPlotPanel.AutoScrollPosition = New System.Drawing.Point(0, 0)


                    If resultsDotPlotPanel.GetChildAtPoint(New System.Drawing.Point(10, 10)) IsNot Nothing Then
                        resultsDotPlotPanel.Controls.Remove(resultsDotPlotPanel.GetChildAtPoint(New System.Drawing.Point(10, 10)))
                    End If
                    Dim dotPlotGrid As DataGridView = New DataGridView
                    dotPlotGrid.Parent = resultsDotPlotPanel
                    dotPlotGrid.Size = New System.Drawing.Size(523, 428)
                    dotPlotGrid.Location = New System.Drawing.Point(10, 10)
                    dotPlotGrid.Name = "resultsDotPlotGrid"
                    Dim sizeOfPanels As Integer = Math.Max(If(zoomToActualButton.Checked, 19,
                                                     Math.Min(19, Math.Min(CInt(Math.Floor(dotPlotGrid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                              CInt(Math.Floor(dotPlotGrid.Size.Height / currentResult.getSequence2().Length - 1))))), 4)
                    dotPlotGrid.ColumnHeadersVisible = True
                    dotPlotGrid.RowHeadersVisible = True
                    dotPlotGrid.ColumnHeadersHeight = sizeOfPanels
                    dotPlotGrid.RowHeadersWidth = sizeOfPanels
                    dotPlotGrid.AllowUserToResizeColumns = False
                    dotPlotGrid.AllowUserToResizeRows = False
                    dotPlotGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
                    dotPlotGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                    dotPlotGrid.AllowUserToAddRows = False
                    dotPlotGrid.AllowUserToDeleteRows = False
                    dotPlotGrid.AllowUserToOrderColumns = False
                    dotPlotGrid.ReadOnly = True
                    Dim style As DataGridViewCellStyle = New DataGridViewCellStyle()
                    style.Font = New Font("Courier New", 10, FontStyle.Regular)
                    dotPlotGrid.Font = New Font("Courier New", 10, FontStyle.Regular)
                    style.BackColor = Color.White
                    style.ForeColor = Color.Black
                    style.Alignment = DataGridViewContentAlignment.TopLeft
                    style.SelectionBackColor = style.BackColor
                    style.SelectionForeColor = style.ForeColor
                    style.WrapMode = DataGridViewTriState.True
                    dotPlotGrid.DefaultCellStyle = style
                    dotPlotGrid.ColumnHeadersDefaultCellStyle = style
                    dotPlotGrid.RowHeadersDefaultCellStyle = style
                    dotPlotGrid.BorderStyle = BorderStyle.None
                    dotPlotGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                    dotPlotGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                    dotPlotGrid.CellBorderStyle = DataGridViewCellBorderStyle.Single
                    dotPlotGrid.BackgroundColor = Color.White
                    dotPlotGrid.GridColor = If(My.Settings.ShowGridLinesDotPlot, Color.LightGray, Color.White)
                    AddHandler dotPlotGrid.RowPrePaint, AddressOf partialPathGrid_RowPrePaint

                    'set column count
                    dotPlotGrid.ColumnCount = currentResult.getSequence1().Length + 1

                    'first column header
                    dotPlotGrid.Columns(0).HeaderText = "_"
                    dotPlotGrid.Columns(0).HeaderCell.Style.Alignment =
                         DataGridViewContentAlignment.MiddleCenter
                    dotPlotGrid.Columns(0).Resizable = DataGridViewTriState.False
                    dotPlotGrid.Columns(0).Width = sizeOfPanels
                    dotPlotGrid.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable

                    ''first create row headers
                    For i As Integer = 1 To dotPlotGrid.ColumnCount - 1
                        dotPlotGrid.Columns(i).HeaderText = currentResult.getSequence1()(i - 1)
                        dotPlotGrid.Columns(i).HeaderCell.Style.Alignment =
                             DataGridViewContentAlignment.MiddleCenter
                        dotPlotGrid.Columns(i).Resizable = DataGridViewTriState.False
                        dotPlotGrid.Columns(i).Width = sizeOfPanels
                        dotPlotGrid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                    Next

                    Dim b As DataGridViewRow = New DataGridViewRow()
                    b.Height = sizeOfPanels
                    b.Resizable = DataGridViewTriState.False
                    b.HeaderCell.Value = "_"
                    dotPlotGrid.Rows.Add(b)

                    For i As Integer = 1 To currentResult.getSequence2().Length
                        Dim currRow As DataGridViewRow = New DataGridViewRow()
                        currRow.Height = sizeOfPanels
                        currRow.Resizable = DataGridViewTriState.False
                        currRow.HeaderCell.Value = currentResult.getSequence2()(i - 1)
                        dotPlotGrid.Rows.Add(currRow)
                    Next
                    'add contents
                    For i As Integer = 1 To dotPlotGrid.RowCount - If(My.Settings.UseWindowingForDotPlot, 2, 1)
                        For j As Integer = 1 To dotPlotGrid.ColumnCount - If(My.Settings.UseWindowingForDotPlot, 2, 1)
                            If My.Settings.UseWindowingForDotPlot Then
                                If j - 2 >= 0 AndAlso j <= currentResult.getSequence1.Length - 1 AndAlso
                                    i - 2 >= 0 AndAlso i <= currentResult.getSequence2.Length - 1 AndAlso
                                    currentResult.getSequence1()(j - 2) = currentResult.getSequence2()(i - 2) AndAlso
                                    currentResult.getSequence1()(j - 1) = currentResult.getSequence2()(i - 1) AndAlso
                                    currentResult.getSequence1()(j) = currentResult.getSequence2()(i) Then
                                    'color three along diagonal
                                    If My.Settings.DotPlotInColor Then
                                        dotPlotGrid.Rows(i - 1).Cells(j - 1).Style.BackColor = My.Settings.GraphicResultsMatchColor
                                        dotPlotGrid.Rows(i - 1).Cells(j - 1).Style.SelectionBackColor = My.Settings.GraphicResultsMatchColor
                                        dotPlotGrid.Rows(i).Cells(j).Style.BackColor = My.Settings.GraphicResultsMatchColor
                                        dotPlotGrid.Rows(i).Cells(j).Style.SelectionBackColor = My.Settings.GraphicResultsMatchColor
                                        dotPlotGrid.Rows(i + 1).Cells(j + 1).Style.BackColor = My.Settings.GraphicResultsMatchColor
                                        dotPlotGrid.Rows(i + 1).Cells(j + 1).Style.SelectionBackColor = My.Settings.GraphicResultsMatchColor
                                    Else
                                        dotPlotGrid.Rows(i - 1).Cells(j - 1).Style.BackColor = Color.Black
                                        dotPlotGrid.Rows(i - 1).Cells(j - 1).Style.SelectionBackColor = Color.Black
                                        dotPlotGrid.Rows(i).Cells(j).Style.BackColor = Color.Black
                                        dotPlotGrid.Rows(i).Cells(j).Style.SelectionBackColor = Color.Black
                                        dotPlotGrid.Rows(i + 1).Cells(j + 1).Style.BackColor = Color.Black
                                        dotPlotGrid.Rows(i + 1).Cells(j + 1).Style.SelectionBackColor = Color.Black
                                    End If
                                End If
                            Else
                                If currentResult.getSequence1()(j - 1) = currentResult.getSequence2()(i - 1) Then
                                    If My.Settings.DotPlotInColor Then
                                        dotPlotGrid.Rows(i).Cells(j).Style.BackColor = My.Settings.GraphicResultsMatchColor
                                        dotPlotGrid.Rows(i).Cells(j).Style.SelectionBackColor = My.Settings.GraphicResultsMatchColor
                                    Else
                                        dotPlotGrid.Rows(i).Cells(j).Style.BackColor = Color.Black
                                        dotPlotGrid.Rows(i).Cells(j).Style.SelectionBackColor = Color.Black
                                    End If
                                End If
                            End If
                        Next
                    Next
                End If

                'density color grid

                Dim resultsDensityColorPanel As Panel = Nothing
                If currentResult.getAlignments.Count > 0 Then
                    If resultsPanelsArray(4) IsNot Nothing Then
                        resultsDensityColorPanel = resultsPanelsArray(4)
                    End If
                    resultsDensityColorPanel = If(resultsDensityColorPanel Is Nothing, New Panel(), resultsDensityColorPanel)
                    resultsDensityColorPanel.Parent = Nothing
                    resultsDensityColorPanel.Size = New System.Drawing.Size(543, 446)
                    resultsDensityColorPanel.Location = New System.Drawing.Point(2, 56)
                    resultsDensityColorPanel.AutoScroll = True
                    resultsDensityColorPanel.Name = "resultsDensityColorPanel"
                    resultsDensityColorPanel.AutoScrollPosition = New System.Drawing.Point(0, 0)


                    If resultsDensityColorPanel.GetChildAtPoint(New System.Drawing.Point(10, 10)) IsNot Nothing Then
                        resultsDensityColorPanel.Controls.Remove(resultsDensityColorPanel.GetChildAtPoint(New System.Drawing.Point(10, 10)))
                    End If
                    Dim densityColorGrid As DataGridView = New DataGridView
                    densityColorGrid.Parent = resultsDensityColorPanel
                    densityColorGrid.Size = New System.Drawing.Size(523, 428)
                    densityColorGrid.Location = New System.Drawing.Point(10, 10)
                    densityColorGrid.Name = "resultsDensityColorGrid"
                    Dim sizeOfPanels As Integer = Math.Max(If(zoomToActualButton.Checked, 19,
                                                     Math.Min(19, Math.Min(CInt(Math.Floor(densityColorGrid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                              CInt(Math.Floor(densityColorGrid.Size.Height / currentResult.getSequence2().Length - 1))))), 4)
                    densityColorGrid.ColumnHeadersVisible = True
                    densityColorGrid.RowHeadersVisible = True
                    densityColorGrid.ColumnHeadersHeight = sizeOfPanels
                    densityColorGrid.RowHeadersWidth = sizeOfPanels
                    densityColorGrid.AllowUserToResizeColumns = False
                    densityColorGrid.AllowUserToResizeRows = False
                    densityColorGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
                    densityColorGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                    densityColorGrid.AllowUserToAddRows = False
                    densityColorGrid.AllowUserToDeleteRows = False
                    densityColorGrid.AllowUserToOrderColumns = False
                    densityColorGrid.ReadOnly = True
                    Dim style As DataGridViewCellStyle = New DataGridViewCellStyle()
                    style.Font = New Font("Courier New", 10, FontStyle.Regular)
                    densityColorGrid.Font = New Font("Courier New", 10, FontStyle.Regular)
                    style.BackColor = Color.White
                    style.ForeColor = Color.Black
                    style.Alignment = DataGridViewContentAlignment.TopLeft
                    style.SelectionBackColor = style.BackColor
                    style.SelectionForeColor = style.ForeColor
                    style.WrapMode = DataGridViewTriState.True
                    densityColorGrid.DefaultCellStyle = style
                    densityColorGrid.ColumnHeadersDefaultCellStyle = style
                    densityColorGrid.RowHeadersDefaultCellStyle = style
                    densityColorGrid.BorderStyle = BorderStyle.None
                    densityColorGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                    densityColorGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                    densityColorGrid.CellBorderStyle = DataGridViewCellBorderStyle.Single
                    densityColorGrid.BackgroundColor = Color.White
                    densityColorGrid.GridColor = If(My.Settings.ShowGridLinesDensityColor, Color.LightGray, Color.White)
                    AddHandler densityColorGrid.RowPrePaint, AddressOf partialPathGrid_RowPrePaint

                    'set column count
                    densityColorGrid.ColumnCount = currentResult.getSequence1().Length + 1

                    'first column header
                    densityColorGrid.Columns(0).HeaderText = "_"
                    densityColorGrid.Columns(0).HeaderCell.Style.Alignment =
                         DataGridViewContentAlignment.MiddleCenter
                    densityColorGrid.Columns(0).Resizable = DataGridViewTriState.False
                    densityColorGrid.Columns(0).Width = sizeOfPanels
                    densityColorGrid.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable

                    'first create row headers
                    For i As Integer = 1 To densityColorGrid.ColumnCount - 1
                        densityColorGrid.Columns(i).HeaderText = currentResult.getSequence1()(i - 1)
                        densityColorGrid.Columns(i).HeaderCell.Style.Alignment =
                             DataGridViewContentAlignment.MiddleCenter
                        densityColorGrid.Columns(i).Resizable = DataGridViewTriState.False
                        densityColorGrid.Columns(i).Width = sizeOfPanels
                        densityColorGrid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                    Next

                    Dim b As DataGridViewRow = New DataGridViewRow()
                    b.Height = sizeOfPanels
                    b.Resizable = DataGridViewTriState.False
                    b.HeaderCell.Value = "_"
                    densityColorGrid.Rows.Add(b)

                    For i As Integer = 1 To currentResult.getSequence2().Length
                        Dim currRow As DataGridViewRow = New DataGridViewRow()
                        currRow.Height = sizeOfPanels
                        currRow.Resizable = DataGridViewTriState.False
                        currRow.HeaderCell.Value = currentResult.getSequence2()(i - 1)
                        densityColorGrid.Rows.Add(currRow)
                    Next
                    'add contents
                    For i As Integer = 0 To densityColorGrid.RowCount - 1
                        For j As Integer = 0 To densityColorGrid.ColumnCount - 1
                            Dim red As Color = System.Drawing.Color.FromArgb(255,
                                                                                 Math.Min(255, CInt(Math.Round(255))),
                                                                                Math.Min(255, CInt(Math.Round(255 - 255 * currentResult.getColorMap(j, i, 0)))),
                                                                                Math.Min(255, CInt(Math.Round(255 - 255 * currentResult.getColorMap(j, i, 0)))))
                            Dim blue As Color = System.Drawing.Color.FromArgb(255,
                                                                                 Math.Min(255, CInt(Math.Round(255 - 255 * currentResult.getColorMap(j, i, 1)))),
                                                                                Math.Min(255, CInt(Math.Round(255 - 255 * currentResult.getColorMap(j, i, 1)))),
                                                                                Math.Min(255, CInt(Math.Round(255))))
                            Dim mix As Color = System.Drawing.Color.FromArgb(255,
                                                                                 CInt(Math.Floor(0.5 * red.R + 0.5 * blue.R)),
                                                                                 CInt(Math.Floor(0.5 * red.G + 0.5 * blue.G)),
                                                                                 CInt(Math.Floor(0.5 * red.B + 0.5 * blue.B)))
                            densityColorGrid.Rows(i).Cells(j).Style.BackColor = If(matchesGapsDCButton.Checked, mix,
                                                                                   If(matchesOnlyDCButton.Checked, red, blue))
                            densityColorGrid.Rows(i).Cells(j).Style.SelectionBackColor = densityColorGrid.Rows(i).Cells(j).Style.BackColor
                        Next
                    Next
                End If
                resultsPanelsArray(0) = resultsPanel
                resultsPanelsArray(1) = resultsSequencePanel
                resultsPanelsArray(2) = resultsPartialPathPanel
                resultsPanelsArray(3) = resultsDotPlotPanel
                resultsPanelsArray(4) = resultsDensityColorPanel
                compareResult(0) = currentResult
                compareMultipleAlignmentsToolStripMenuItem.Enabled = True
                SaveAlignmentLAVTToolStripMenuItem.Enabled = True
            End If
            If viewCombobox.SelectedItem.ToString = "Grid View" AndAlso
                resultsPanelsArray(0) IsNot Nothing Then
                resultsGB.Controls.Add(resultsPanelsArray(0))
                If currentResult.getAlignments.Count > 1 Then
                    orderByLabel.Visible = True
                    orderByComboBox.Visible = True
                Else
                    orderByLabel.Visible = False
                    orderByComboBox.Visible = False
                End If
                zoomToActualButton.Enabled = True
                zoomToFitButton.Enabled = True
                ZoomToFitToolStripMenuItem.Enabled = True
                ZoomToActualSizeToolStripMenuItem.Enabled = True
                matchesGapsDCButton.Visible = False
                gapsOnlyDCButton.Visible = False
                matchesOnlyDCButton.Visible = False
            ElseIf viewCombobox.SelectedItem.ToString = "Sequence View" AndAlso
                resultsPanelsArray(1) IsNot Nothing Then
                resultsGB.Controls.Add(resultsPanelsArray(1))
                If currentResult.getAlignments.Count > 1 Then
                    orderByLabel.Visible = True
                    orderByComboBox.Visible = True
                Else
                    orderByLabel.Visible = False
                    orderByComboBox.Visible = False
                End If
                zoomToActualButton.Enabled = False
                zoomToFitButton.Enabled = False
                ZoomToFitToolStripMenuItem.Enabled = False
                ZoomToActualSizeToolStripMenuItem.Enabled = False
                matchesGapsDCButton.Visible = False
                gapsOnlyDCButton.Visible = False
                matchesOnlyDCButton.Visible = False
            ElseIf viewCombobox.SelectedItem.ToString = "Partial Path View" AndAlso
                resultsPanelsArray(2) IsNot Nothing Then
                resultsGB.Controls.Add(resultsPanelsArray(2))
                orderByLabel.Visible = False
                orderByComboBox.Visible = False
                suboptimalFirstButton.Visible = False
                suboptimalLastButton.Visible = False
                suboptimalRightButton.Visible = False
                suboptimalLeftButton.Visible = False
                zoomToActualButton.Enabled = True
                zoomToFitButton.Enabled = True
                ZoomToFitToolStripMenuItem.Enabled = True
                matchesGapsDCButton.Visible = False
                gapsOnlyDCButton.Visible = False
                matchesOnlyDCButton.Visible = False
                ZoomToActualSizeToolStripMenuItem.Enabled = True
                If statResultsGB.HasChildren Then
                    statResultsGB.Controls.Remove(statResultsGB.GetChildAtPoint(New System.Drawing.Point(2, 18)))
                End If
            ElseIf viewCombobox.SelectedItem.ToString = "Dot Plot View" AndAlso
                resultsPanelsArray(3) IsNot Nothing Then
                resultsGB.Controls.Add(resultsPanelsArray(3))
                orderByLabel.Visible = False
                orderByComboBox.Visible = False
                suboptimalFirstButton.Visible = False
                suboptimalLastButton.Visible = False
                suboptimalRightButton.Visible = False
                suboptimalLeftButton.Visible = False
                matchesGapsDCButton.Visible = False
                gapsOnlyDCButton.Visible = False
                matchesOnlyDCButton.Visible = False
                zoomToActualButton.Enabled = True
                zoomToFitButton.Enabled = True
                ZoomToFitToolStripMenuItem.Enabled = True
                ZoomToActualSizeToolStripMenuItem.Enabled = True
                If statResultsGB.HasChildren Then
                    statResultsGB.Controls.Remove(statResultsGB.GetChildAtPoint(New System.Drawing.Point(2, 18)))
                End If
            ElseIf viewCombobox.SelectedItem.ToString = "Density Color View" AndAlso
                resultsPanelsArray(4) IsNot Nothing Then
                resultsGB.Controls.Add(resultsPanelsArray(4))
                orderByLabel.Visible = False
                orderByComboBox.Visible = False
                suboptimalFirstButton.Visible = False
                suboptimalLastButton.Visible = False
                suboptimalRightButton.Visible = False
                suboptimalLeftButton.Visible = False
                matchesGapsDCButton.Visible = True
                gapsOnlyDCButton.Visible = True
                matchesOnlyDCButton.Visible = True
                zoomToActualButton.Enabled = True
                zoomToFitButton.Enabled = True
                ZoomToFitToolStripMenuItem.Enabled = True
                ZoomToActualSizeToolStripMenuItem.Enabled = True
                If statResultsGB.HasChildren Then
                    statResultsGB.Controls.Remove(statResultsGB.GetChildAtPoint(New System.Drawing.Point(2, 18)))
                End If
            ElseIf viewCombobox.SelectedItem.ToString = "Comparative View" AndAlso
                resultsPanelsArray(5) IsNot Nothing Then
                resultsGB.Controls.Add(resultsPanelsArray(5))
                orderByLabel.Visible = False
                orderByComboBox.Visible = False
                suboptimalFirstButton.Visible = False
                suboptimalLastButton.Visible = False
                suboptimalRightButton.Visible = False
                suboptimalLeftButton.Visible = False
                matchesGapsDCButton.Visible = False
                gapsOnlyDCButton.Visible = False
                matchesOnlyDCButton.Visible = False
                zoomToActualButton.Enabled = True
                zoomToFitButton.Enabled = True
                ZoomToFitToolStripMenuItem.Enabled = True
                ZoomToActualSizeToolStripMenuItem.Enabled = True
                If statResultsGB.HasChildren Then
                    statResultsGB.Controls.Remove(statResultsGB.GetChildAtPoint(New System.Drawing.Point(2, 18)))
                End If
            End If
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show(ex.toString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            displayLog()
        Finally
            Me.Enabled = True
        End Try
    End Sub
    Public Sub displayLog()
        Try
            For Each s As String In debugLog
                Console.WriteLine(s)
            Next
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show("Logging Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub parseInto(fileName As String, t As RichTextBox)
        Try
            Dim fileReader As String
            fileReader = My.Computer.FileSystem.ReadAllText(fileName)
            t.Text = filterOut(fileReader)
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show(ex.toString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            displayLog()
        End Try
    End Sub
    Private Function filterOut(s As String) As String
        Dim showError As Boolean = False
        Dim returnString As String = String.Empty
        'loop through each character
        For i As Integer = 0 To s.Length - 1
            If isDNAChar(s(i)) Then
                returnString &= s(i)
            Else
                showError = True
            End If
        Next
        If showError Then
            MessageBox.Show("The sequence you have selected contains characters that are not valid." & Environment.NewLine &
                            "Only the valid sequence characters will be recognized.", "Import Sequence Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return returnString
    End Function
    Public Sub setSavedResults(r As Result())
        compareResult = r
    End Sub
    Public Sub setUnsavedResult(b As Boolean)
        unsavedResult = b
    End Sub
    Public Sub loadFile()
        Me.Enabled = False
        Dim fDialog As OpenFileDialog = New OpenFileDialog
        fDialog.Title = "Local Alignment Visualization Tool Result Load Dialog"
        fDialog.InitialDirectory = My.Application.Info.DirectoryPath
        fDialog.Filter = "Local Alignment Visualization Tool Result Files (*.LAVTR)|*.LAVTR|All Files (*.*)|*.*"
        fDialog.FilterIndex = 1
        fDialog.RestoreDirectory = True

        Dim result As DialogResult = fDialog.ShowDialog()
        If result = DialogResult.OK Then
            'parse text into sequence 1 box
            currentResult = New Result(fDialog.FileName, True)
            clearInputValues()
            If currentResult.getAlignments() IsNot Nothing AndAlso currentResult.getAlignments().Count > 0 Then
                displayAlignment(0)
            End If
        End If
        Me.Enabled = True
    End Sub
    Public Sub saveMatrix(file As String)
        Try
            Dim returnString As String = String.Empty
            'seperate rows with |
            'seperate indexes with ,
            For i As Integer = 0 To currentScoringMatrix.GetUpperBound(0)
                For j As Integer = 0 To currentScoringMatrix.GetUpperBound(1)
                    returnString &= currentScoringMatrix(i, j) & "&"
                Next
                returnString = returnString.Substring(0, returnString.Length - 1) & "|"
            Next
            returnString = returnString.Substring(0, returnString.Length - 1)
            My.Computer.FileSystem.WriteAllText(file, returnString, False)
            MessageBox.Show("Save Successful!", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            unsavedMatrix = False
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show(ex.toString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            displayLog()
        End Try
    End Sub
    Public Sub loadMatrix()
        Me.Enabled = False
        Dim fDialog As OpenFileDialog = New OpenFileDialog
        fDialog.Title = "Local Alignment Visualization Tool Scoring Matrix Load Dialog"
        fDialog.InitialDirectory = My.Application.Info.DirectoryPath
        fDialog.Filter = "Local Alignment Visualization Tool Scoring Matrix Files (*.LAVTSM)|*.LAVTSM|All Files (*.*)|*.*"
        fDialog.FilterIndex = 1
        fDialog.RestoreDirectory = True

        Dim result As DialogResult = fDialog.ShowDialog()
        If result = DialogResult.OK Then
            'parse text into sequence 1 box
            loadMatrixFromFile(fDialog.FileName)
            setLastCustomMatrix(currentScoringMatrix)
        End If
        useScoringMatrixCB.Checked = True
        scoringMatrixComboBox.SelectedIndex = 5
        Me.Enabled = True
    End Sub
    Private Sub loadMatrixFromFile(fileString As String)
        'open file to parse into strings
        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader(fileString)

        Dim iValues As String() = fileReader.ReadLine.Split("|"c)
        Dim returnArray(iValues.GetUpperBound(0), countCharacter(iValues(0), "&"c)) As Double
        For i As Integer = 0 To iValues.GetUpperBound(0)
            Dim jValues As String() = iValues(i).Split("&"c)
            For v As Integer = 0 To jValues.GetUpperBound(0)
                returnArray(i, v) = CDbl(jValues(v))
            Next
        Next
        setScoringMatrix(returnArray)
        unsavedMatrix = False
    End Sub
    Private Function countCharacter(s As String, ch As Char) As Integer
        Dim cnt As Integer = 0
        For Each c As Char In s
            If c = ch Then cnt += 1
        Next
        Return cnt
    End Function
    Private Function getMatrixFileName() As String
        'search this directory
        Dim directoryPath As String = My.Application.Info.DirectoryPath
        Dim directory As System.IO.DirectoryInfo = New IO.DirectoryInfo(directoryPath)

        Dim prefaceString As String = "CustomScoringMatrix"
        Dim prefaceNumber As Integer = 1
        Dim foundFile As Boolean = False
        While Not foundFile
            foundFile = True
            For Each f As IO.FileInfo In directory.GetFiles
                If f.Name = prefaceString & prefaceNumber & ".LAVTSM" Then
                    prefaceNumber += 1
                    foundFile = False
                    Exit For
                End If
            Next
        End While
        Return prefaceString & prefaceNumber
    End Function
    'control object methods
    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click, ExitToolStripMenuItem.Click
        'if there is unsaved data, ask the user if they're sure they want to close
        'otherwise just close
        If unsavedMatrix OrElse unsavedResult Then
            Dim askResponse As DialogResult = MessageBox.Show("There are unsaved changes. Would you like to save before you close?",
                                                   "Exit Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
            If askResponse = Windows.Forms.DialogResult.No Then
                If currentResult IsNot Nothing AndAlso currentResult.workerIsWorking Then
                    'cancel and wait
                    currentResult.passMainForm(Me)
                    currentResult.setCloseAfterCancel(True)
                    currentResult.cancelWorker()
                Else
                    Me.Close()
                End If
            ElseIf askResponse = Windows.Forms.DialogResult.Yes Then
                If unsavedResult Then
                    If currentResult IsNot Nothing Then
                        currentResult.passMainForm(Me)
                        currentResult.setCloseAfterSave(True)
                    End If
                    SaveAlignmentLAVTToolStripMenuItem.PerformClick()
                ElseIf unsavedMatrix Then
                    SaveScoringMatrixLAVTSMToolStripMenuItem.PerformClick()
                End If
            End If
        Else
            If currentResult IsNot Nothing AndAlso currentResult.workerIsWorking Then
                'cancel and wait
                currentResult.passMainForm(Me)
                currentResult.setCloseAfterCancel(True)
                currentResult.cancelWorker()
            Else
                Me.Close()
            End If
        End If
    End Sub
    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        Me.Enabled = False
        Dim settingsF As settingsForm = New settingsForm()
        settingsF.passData(Me, getAminoAcidList())
        settingsF.Show()
    End Sub
    Private Sub seq1Rtextbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles seq1Rtextbox.KeyPress, seq2Rtextbox.KeyPress
        'convert to uppercase
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If

        If My.Settings.DNACharsOnly Then
            If Not isDNAChar(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
                e.Handled = True
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
                Dim currentControl As RichTextBox = CType(sender, RichTextBox)
                warningToolTip.Show("You may only enter DNA Characters!", currentControl.Parent,
                                  New Point(CInt(currentControl.Location.X + currentControl.Width / 2),
                                            currentControl.Location.Y - 50), 3000)
            End If
        End If
    End Sub
    Private Sub optimalThresholdTextbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles optimalThresholdTextbox.KeyPress
        'numbers only
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso
            e.KeyChar <> ControlChars.Back AndAlso (e.KeyChar <> "-" OrElse optimalThresholdTextbox.Text <> String.Empty) Then
            e.Handled = True
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
            warningToolTip.Show("You may only enter numbers!", optimalThresholdTextbox.Parent,
                              New Point(CInt(optimalThresholdTextbox.Location.X + optimalThresholdTextbox.Width / 2),
                                        optimalThresholdTextbox.Location.Y - 50), 3000)
        End If
    End Sub
    Private Sub scoringMatrixQMTT_Click(sender As Object, e As EventArgs) Handles scoringMatrixQMTT.Click
        If useScoringMatrixCB.Checked Then
            Me.Enabled = False
            Dim scoringMatrixF As scoringMatrixViewer = New scoringMatrixViewer()
            scoringMatrixF.passData(Me, aminoAcidList)
            scoringMatrixF.Show()
        End If
    End Sub
    Private Sub scoringMatrixComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles scoringMatrixComboBox.SelectedIndexChanged
        Select Case scoringMatrixComboBox.SelectedIndex
            Case 0
                pamNumberTextbox.Enabled = False
                setScoringMatrix(DEFAULT_MATRIX)
            Case 1
                pamNumberTextbox.Enabled = True
                setScoringMatrix(PAM1)
            Case 2
                pamNumberTextbox.Enabled = False
                setScoringMatrix(BLOSUM45)
            Case 3
                pamNumberTextbox.Enabled = False
                setScoringMatrix(BLOSUM62)
            Case 4
                pamNumberTextbox.Enabled = False
                setScoringMatrix(BLOSUM80)
            Case 5
                pamNumberTextbox.Enabled = False
                Me.Enabled = False
                Dim scoringMatrixC As scoringMatrixCustomizer = New scoringMatrixCustomizer()
                scoringMatrixC.passData(Me, aminoAcidList, lastCustomMatrix)
                scoringMatrixC.Show()
            Case Else
                'error
                pamNumberTextbox.Enabled = False
        End Select
    End Sub
    Private Sub pamNumberTextbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles pamNumberTextbox.KeyPress
        'numbers only
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso
            e.KeyChar <> ControlChars.Back Then
            e.Handled = True
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
            warningToolTip.Show("You may only enter positive numbers!", pamNumberTextbox.Parent,
                              New Point(CInt(pamNumberTextbox.Location.X + pamNumberTextbox.Width / 2),
                                        pamNumberTextbox.Location.Y - 50), 3000)
        End If
    End Sub
    Private Sub optThreshRB_CheckedChanged(sender As Object, e As EventArgs) Handles optThreshRB.CheckedChanged
        optimalThresholdLabel.Text = "Optimal Threshold:"
        requiredLabel5.Location = New System.Drawing.Point(120, 74)
    End Sub
    Private Sub eValueRB_CheckedChanged(sender As Object, e As EventArgs) Handles eValueRB.CheckedChanged
        optimalThresholdLabel.Text = "'e' Value:"
        requiredLabel5.Location = New System.Drawing.Point(61, 74)
    End Sub
    Private Sub gapPenaltyCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gapPenaltyCB.SelectedIndexChanged
        Select Case gapPenaltyCB.SelectedIndex
            Case 0
                penaltyValueTwoLabel.Visible = False
                penaltyValueTwoTextbox.Visible = False
                requiredLabel7.Visible = False
                gapPenaltyValueLabel.Text = "Penalty Value:"
                requiredLabel6.Location = New System.Drawing.Point(90, 49)
            Case 1
                penaltyValueTwoLabel.Visible = False
                penaltyValueTwoTextbox.Visible = False
                requiredLabel7.Visible = False
                gapPenaltyValueLabel.Text = "Penalty Value:"
                requiredLabel6.Location = New System.Drawing.Point(90, 49)
            Case 2
                penaltyValueTwoLabel.Visible = True
                penaltyValueTwoTextbox.Visible = True
                requiredLabel7.Visible = True
                gapPenaltyValueLabel.Text = "Gap Opening Penalty:"
                requiredLabel6.Location = New System.Drawing.Point(136, 49)
        End Select
    End Sub
    Private Sub penaltyValueTextbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles penaltyValueTextbox.KeyPress
        'numbers only
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso
            e.KeyChar <> ControlChars.Back AndAlso e.KeyChar <> "." AndAlso
            (e.KeyChar <> "-" OrElse penaltyValueTextbox.Text <> String.Empty) Then
            e.Handled = True
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
            warningToolTip.Show("You may only enter numbers!", penaltyValueTextbox.Parent,
                              New Point(CInt(penaltyValueTextbox.Location.X + penaltyValueTextbox.Width / 2),
                                        penaltyValueTextbox.Location.Y - 50), 3000)
        End If
    End Sub
    Private Sub penaltyValueTwoTextbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles penaltyValueTwoTextbox.KeyPress
        'numbers and periods only
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso
            e.KeyChar <> ControlChars.Back AndAlso e.KeyChar <> "." AndAlso
            (e.KeyChar <> "-" OrElse penaltyValueTwoTextbox.Text <> String.Empty) Then
            e.Handled = True
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
            warningToolTip.Show("You may only enter numbers!", penaltyValueTwoTextbox.Parent,
                              New Point(CInt(penaltyValueTwoTextbox.Location.X + penaltyValueTwoTextbox.Width / 2),
                                        penaltyValueTwoTextbox.Location.Y - 50), 3000)
        End If
    End Sub
    Private Sub goButton_Click(sender As Object, e As EventArgs) Handles goButton.Click
        Try
            Dim allRequiredFieldsEntered As Boolean = True
            sequence1Label.ForeColor = Color.Black
            sequence2Label.ForeColor = Color.Black
            pamNumLabel.ForeColor = Color.Black
            optimalThresholdLabel.ForeColor = Color.Black
            penaltyValueTwoLabel.ForeColor = Color.Black
            gapPenaltyValueLabel.ForeColor = Color.Black
            matchValueLabel.ForeColor = Color.Black
            mismatchValueLabel.ForeColor = Color.Black
            unsavedResult = True
            If currentResult IsNot Nothing Then
                currentResult.setCloseAfterCancel(False)
                currentResult.cancelWorker()
            End If
            currentResult = Nothing

            'parse pam textbox
            Dim pamNumber As Integer = -1
            Integer.TryParse(pamNumberTextbox.Text, pamNumber)

            'parse opt thresh/e value textbox
            Dim optThresh As Integer
            If Not Integer.TryParse(optimalThresholdTextbox.Text, optThresh) Then
                optThresh = Integer.MinValue
            End If

            'parse penalty value textbox
            Dim aValue As Double
            If Not Double.TryParse(penaltyValueTextbox.Text, aValue) Then
                aValue = Double.MinValue
            End If

            'parse b value textbox
            Dim bValue As Double
            If Not Double.TryParse(penaltyValueTwoTextbox.Text, bValue) Then
                bValue = Double.MinValue
            End If

            'check first sequence
            Dim seq1 As String = seq1Rtextbox.Text.Trim
            If seq1 = String.Empty Then
                allRequiredFieldsEntered = False
                sequence1Label.ForeColor = Color.Red
            End If

            'check second sequence
            Dim seq2 As String = seq2Rtextbox.Text.Trim
            If seq2 = String.Empty Then
                allRequiredFieldsEntered = False
                sequence2Label.ForeColor = Color.Red
            End If

            'check scoring matrices
            If useScoringMatrixCB.Checked Then
                If (scoringMatrixComboBox.SelectedIndex = 1 AndAlso (pamNumber <= 0 OrElse pamNumber > 1000)) Then
                    allRequiredFieldsEntered = False
                    pamNumLabel.ForeColor = Color.Red
                End If
            Else
                If matchValueTextbox.Text = String.Empty Then
                    allRequiredFieldsEntered = False
                    matchValueLabel.ForeColor = Color.Red
                End If
                If mismatchValueTextbox.Text = String.Empty Then
                    allRequiredFieldsEntered = False
                    mismatchValueLabel.ForeColor = Color.Red
                End If
            End If

            'check optimal threshold
            If ((optThreshRB.Checked AndAlso optThresh = Integer.MinValue) OrElse
                 (eValueRB.Checked AndAlso optThresh < 0)) Then
                allRequiredFieldsEntered = False
                optimalThresholdLabel.ForeColor = Color.Red
            End If

            'check gap penalty a value
            If aValue = Integer.MinValue Then
                allRequiredFieldsEntered = False
                gapPenaltyValueLabel.ForeColor = Color.Red
            End If

            'check gap penalty b value
            If (gapPenaltyCB.SelectedIndex = 2 AndAlso bValue = Integer.MinValue) Then
                allRequiredFieldsEntered = False
                penaltyValueTwoLabel.ForeColor = Color.Red
            End If

            'check if all require fields are filled
            If Not allRequiredFieldsEntered Then
                MessageBox.Show("You must enter something in all required fields!" & Environment.NewLine &
                                "Please check required fields and try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                'parse pam matrix
                If scoringMatrixComboBox.SelectedIndex = 1 Then
                    setScoringMatrix(getPAM(pamNumber))
                End If

                If Not useScoringMatrixCB.Checked Then
                    Dim scoringMatrix(DEFAULT_MATRIX.GetUpperBound(0), DEFAULT_MATRIX.GetUpperBound(1)) As Double
                    Dim matchValue As Double
                    Dim mismatchvalue As Double
                    Double.TryParse(matchValueTextbox.Text, matchValue)
                    Double.TryParse(mismatchValueTextbox.Text, mismatchvalue)
                    For i As Integer = 0 To scoringMatrix.GetUpperBound(0)
                        For j As Integer = 0 To scoringMatrix.GetUpperBound(1)
                            scoringMatrix(i, j) = CDbl(If(i = j, matchValue, mismatchvalue))
                        Next
                    Next
                    setScoringMatrix(scoringMatrix)
                End If

                'perform algorithm
                Dim gapType As GAP_TYPE = If(CStr(gapPenaltyCB.SelectedItem) = "Linear", GAP_TYPE.LINEAR,
                                             If(CStr(gapPenaltyCB.SelectedItem) = "Constant", GAP_TYPE.CONSTANT,
                                                GAP_TYPE.AFFINE))
                currentResult = smithWaterman(seq1, seq2, currentScoringMatrix,
                                              gapType, aValue, optThresh, eValueRB.Checked, ignoreIntersectionsCB.Checked,
                                              If(gapType = GAP_TYPE.AFFINE,
                                                 bValue, Nothing))
                If currentResult IsNot Nothing Then
                    Select Case orderByComboBox.SelectedItem.ToString
                        Case "Score"
                            currentResult.orderAlignmentsBy(Result.ORDER_TYPE.SCORE)
                        Case "Length"
                            currentResult.orderAlignmentsBy(Result.ORDER_TYPE.LENGTH)
                        Case "Number of Gaps"
                            currentResult.orderAlignmentsBy(Result.ORDER_TYPE.GAPS)
                        Case "Number of Matches"
                            currentResult.orderAlignmentsBy(Result.ORDER_TYPE.MATCHES)
                        Case Else
                            currentResult.orderAlignmentsBy(Result.ORDER_TYPE.MISMATCHES)
                            'mismatches
                    End Select
                End If
                If currentResult Is Nothing OrElse currentResult.getAlignments Is Nothing OrElse currentResult.getAlignments.Count < 1 Then
                    MessageBox.Show("There are no alignments " & If(eValueRB.Checked, "with the given e-value", "above the given threshold") &
                                    Environment.NewLine & "Adjust your values and try again.", "No alignments found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    displayAlignment(0)
                End If
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            End If
        Catch ex As Exception
            debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            displayLog()
        End Try
    End Sub
    Private Sub useScoringMatrixCB_CheckedChanged(sender As Object, e As EventArgs) Handles useScoringMatrixCB.CheckedChanged
        If useScoringMatrixCB.Checked Then
            requiredLabel4.Visible = True
            scoringMatrixComboBox.Visible = True
            scoringMatrixLabel.Visible = True
            pamNumLabel.Visible = True
            pamNumberTextbox.Visible = True

            matchValueLabel.Visible = False
            mismatchValueLabel.Visible = False
            requiredLabel9.Visible = False
            requiredLabel8.Visible = False
            matchValueTextbox.Visible = False
            mismatchValueTextbox.Visible = False

            infoToolTip.SetToolTip(scoringMatrixQMTT, "The scoring matrix is how the algorithm will determine" &
                                   Environment.NewLine & "the score of a local alignment. You can use the default" &
                                   Environment.NewLine & "matrix, a PAM matrix with specified number (1 to 10000), " &
                                   Environment.NewLine & "BLOSUM45, BLOSUM62, BLOSUM80, or build your own " &
                                   Environment.NewLine & "custom scoring matrix." &
                                   Environment.NewLine & Environment.NewLine & "Click here to view the matrices.")
        Else
            requiredLabel4.Visible = False
            scoringMatrixComboBox.Visible = False
            scoringMatrixLabel.Visible = False
            pamNumLabel.Visible = False
            pamNumberTextbox.Visible = False

            matchValueLabel.Visible = True
            mismatchValueLabel.Visible = True
            requiredLabel9.Visible = True
            requiredLabel8.Visible = True
            matchValueTextbox.Visible = True
            mismatchValueTextbox.Visible = True

            infoToolTip.SetToolTip(scoringMatrixQMTT, "The match and mismatch values are how the algorithm " &
                                   Environment.NewLine & "will determine the score of a local alignment. The match" &
                                   Environment.NewLine & "value represents the score when there is a match of" &
                                   Environment.NewLine & "characters, and the mismatch value represents the" &
                                   Environment.NewLine & "score when there is not a match of characters." &
                                   Environment.NewLine & Environment.NewLine & "These boxes both accept only integers!")
        End If
    End Sub
    Private Sub matchValueTextbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles matchValueTextbox.KeyPress
        'numbers only
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso
            e.KeyChar <> ControlChars.Back AndAlso e.KeyChar <> "." AndAlso
            (e.KeyChar <> "-" OrElse matchValueTextbox.Text <> String.Empty) Then
            e.Handled = True
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
            warningToolTip.Show("You may only enter numbers!", matchValueTextbox.Parent,
                              New Point(CInt(matchValueTextbox.Location.X + matchValueTextbox.Width / 2),
                                        matchValueTextbox.Location.Y - 50), 3000)
        End If
    End Sub
    Private Sub mismatchValueTextbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mismatchValueTextbox.KeyPress
        'numbers only
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso
            e.KeyChar <> ControlChars.Back AndAlso e.KeyChar <> "." AndAlso
            (e.KeyChar <> "-" OrElse mismatchValueTextbox.Text <> String.Empty) Then
            e.Handled = True
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
            warningToolTip.Show("You may only enter numbers!", mismatchValueTextbox.Parent,
                              New Point(CInt(mismatchValueTextbox.Location.X + mismatchValueTextbox.Width / 2),
                                        mismatchValueTextbox.Location.Y - 50), 3000)
        End If
    End Sub
    Private Sub suboptimalLeftButton_Click(sender As Object, e As EventArgs) Handles suboptimalLeftButton.Click
        If currentlyDisplayedAlignment > 0 AndAlso currentResult.getAlignments.Count > 1 Then
            'display alignment of previous number
            displayAlignment(currentlyDisplayedAlignment - 1)
        End If
    End Sub
    Private Sub suboptimalRightButton_Click(sender As Object, e As EventArgs) Handles suboptimalRightButton.Click
        If currentlyDisplayedAlignment < currentResult.getAlignments.Count - 1 AndAlso
            currentResult.getAlignments.Count > 1 Then
            'display alignment of next number
            displayAlignment(currentlyDisplayedAlignment + 1)
        End If
    End Sub
    Private Sub suboptimalFirstButton_Click(sender As Object, e As EventArgs) Handles suboptimalFirstButton.Click
        If currentlyDisplayedAlignment > 0 AndAlso currentResult.getAlignments.Count > 1 Then
            'display alignment of previous number
            displayAlignment(0)
        End If
    End Sub
    Private Sub suboptimalLastButton_Click(sender As Object, e As EventArgs) Handles suboptimalLastButton.Click
        If currentlyDisplayedAlignment < currentResult.getAlignments.Count - 1 AndAlso
            currentResult.getAlignments.Count > 1 Then
            'display alignment of next number
            displayAlignment(currentResult.getAlignments.Count - 1)
        End If
    End Sub
    Private Sub viewCombobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles viewCombobox.SelectedIndexChanged
        If viewCombobox.SelectedItem.ToString = "Grid View" AndAlso
            resultsPanelsArray(1) IsNot Nothing AndAlso resultsPanelsArray(0) IsNot Nothing AndAlso
            resultsPanelsArray(2) IsNot Nothing AndAlso
            resultsPanelsArray(3) IsNot Nothing AndAlso
            resultsPanelsArray(4) IsNot Nothing Then
            PartialPathViewToolStripMenuItem.Checked = False
            DensityColorGridViewToolStripMenuItem.Checked = False
            DotPlotViewToolStripMenuItem.Checked = False
            GridViewToolStripMenuItem.Checked = True
            SequenceViewToolStripMenuItem.Checked = False
            If resultsGB.Controls.Contains(resultsPanelsArray(1)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(1))
            End If
            If resultsGB.Controls.Contains(resultsPanelsArray(2)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(2))
            End If
            If resultsGB.Controls.Contains(resultsPanelsArray(3)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(3))
            End If
            If resultsGB.Controls.Contains(resultsPanelsArray(4)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(4))
            End If
            resultsGB.Controls.Add(resultsPanelsArray(0))
            If currentResult.getAlignments.Count > 1 Then
                orderByLabel.Visible = True
                orderByComboBox.Visible = True
            Else
                orderByLabel.Visible = False
                orderByComboBox.Visible = False
            End If
            suboptimalFirstButton.Visible = True
            suboptimalLastButton.Visible = True
            suboptimalRightButton.Visible = True
            suboptimalLeftButton.Visible = True
            matchesGapsDCButton.Visible = False
            gapsOnlyDCButton.Visible = False
            matchesOnlyDCButton.Visible = False
            zoomToActualButton.Enabled = True
            zoomToFitButton.Enabled = True
            ZoomToFitToolStripMenuItem.Enabled = True
            ZoomToActualSizeToolStripMenuItem.Enabled = True
            statResultsGB.Controls.Add(statsPanel)
        ElseIf viewCombobox.SelectedItem.ToString = "Sequence View" AndAlso
            resultsPanelsArray(1) IsNot Nothing AndAlso resultsPanelsArray(0) IsNot Nothing AndAlso
            resultsPanelsArray(2) IsNot Nothing AndAlso
            resultsPanelsArray(3) IsNot Nothing AndAlso
            resultsPanelsArray(4) IsNot Nothing Then
            PartialPathViewToolStripMenuItem.Checked = False
            DensityColorGridViewToolStripMenuItem.Checked = False
            DotPlotViewToolStripMenuItem.Checked = False
            GridViewToolStripMenuItem.Checked = False
            SequenceViewToolStripMenuItem.Checked = True
            If resultsGB.Controls.Contains(resultsPanelsArray(0)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(0))
            End If
            If resultsGB.Controls.Contains(resultsPanelsArray(2)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(2))
            End If
            If resultsGB.Controls.Contains(resultsPanelsArray(3)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(3))
            End If
            If resultsGB.Controls.Contains(resultsPanelsArray(4)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(4))
            End If
            resultsGB.Controls.Add(resultsPanelsArray(1))
            If currentResult.getAlignments.Count > 1 Then
                orderByLabel.Visible = True
                orderByComboBox.Visible = True
            Else
                orderByLabel.Visible = False
                orderByComboBox.Visible = False
            End If
            suboptimalFirstButton.Visible = True
            suboptimalLastButton.Visible = True
            suboptimalRightButton.Visible = True
            suboptimalLeftButton.Visible = True
            matchesGapsDCButton.Visible = False
            gapsOnlyDCButton.Visible = False
            matchesOnlyDCButton.Visible = False
            zoomToActualButton.Enabled = False
            zoomToFitButton.Enabled = False
            ZoomToFitToolStripMenuItem.Enabled = False
            ZoomToActualSizeToolStripMenuItem.Enabled = False
            statResultsGB.Controls.Add(statsPanel)
        ElseIf viewCombobox.SelectedItem.ToString = "Partial Path View" AndAlso
            resultsPanelsArray(1) IsNot Nothing AndAlso resultsPanelsArray(0) IsNot Nothing AndAlso
            resultsPanelsArray(2) IsNot Nothing AndAlso
            resultsPanelsArray(3) IsNot Nothing AndAlso
            resultsPanelsArray(4) IsNot Nothing Then
            PartialPathViewToolStripMenuItem.Checked = True
            DensityColorGridViewToolStripMenuItem.Checked = False
            DotPlotViewToolStripMenuItem.Checked = False
            GridViewToolStripMenuItem.Checked = False
            SequenceViewToolStripMenuItem.Checked = False
            If resultsGB.Controls.Contains(resultsPanelsArray(0)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(0))
            End If
            If resultsGB.Controls.Contains(resultsPanelsArray(1)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(1))
            End If
            If resultsGB.Controls.Contains(resultsPanelsArray(3)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(3))
            End If
            If resultsGB.Controls.Contains(resultsPanelsArray(4)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(4))
            End If
            resultsGB.Controls.Add(resultsPanelsArray(2))
            orderByLabel.Visible = False
            orderByComboBox.Visible = False
            suboptimalFirstButton.Visible = False
            suboptimalLastButton.Visible = False
            suboptimalRightButton.Visible = False
            suboptimalLeftButton.Visible = False
            matchesGapsDCButton.Visible = False
            gapsOnlyDCButton.Visible = False
            matchesOnlyDCButton.Visible = False
            zoomToActualButton.Enabled = True
            zoomToFitButton.Enabled = True
            ZoomToFitToolStripMenuItem.Enabled = True
            ZoomToActualSizeToolStripMenuItem.Enabled = True
            If statResultsGB.HasChildren Then
                statResultsGB.Controls.Remove(statsPanel)
            End If
        ElseIf viewCombobox.SelectedItem.ToString = "Dot Plot View" AndAlso
            resultsPanelsArray(1) IsNot Nothing AndAlso resultsPanelsArray(0) IsNot Nothing AndAlso
            resultsPanelsArray(2) IsNot Nothing AndAlso
            resultsPanelsArray(3) IsNot Nothing AndAlso
            resultsPanelsArray(4) IsNot Nothing Then
            PartialPathViewToolStripMenuItem.Checked = False
            DensityColorGridViewToolStripMenuItem.Checked = False
            DotPlotViewToolStripMenuItem.Checked = True
            GridViewToolStripMenuItem.Checked = False
            SequenceViewToolStripMenuItem.Checked = False
            If resultsGB.Controls.Contains(resultsPanelsArray(0)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(0))
            End If
            If resultsGB.Controls.Contains(resultsPanelsArray(1)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(1))
            End If
            If resultsGB.Controls.Contains(resultsPanelsArray(2)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(2))
            End If
            If resultsGB.Controls.Contains(resultsPanelsArray(4)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(4))
            End If
            resultsGB.Controls.Add(resultsPanelsArray(3))
            orderByLabel.Visible = False
            orderByComboBox.Visible = False
            suboptimalFirstButton.Visible = False
            suboptimalLastButton.Visible = False
            suboptimalRightButton.Visible = False
            suboptimalLeftButton.Visible = False
            matchesGapsDCButton.Visible = False
            gapsOnlyDCButton.Visible = False
            matchesOnlyDCButton.Visible = False
            zoomToActualButton.Enabled = True
            zoomToFitButton.Enabled = True
            ZoomToFitToolStripMenuItem.Enabled = True
            ZoomToActualSizeToolStripMenuItem.Enabled = True
            If statResultsGB.HasChildren Then
                statResultsGB.Controls.Remove(statsPanel)
            End If
        ElseIf viewCombobox.SelectedItem.ToString = "Density Color View" AndAlso
            resultsPanelsArray(1) IsNot Nothing AndAlso resultsPanelsArray(0) IsNot Nothing AndAlso
            resultsPanelsArray(2) IsNot Nothing AndAlso
            resultsPanelsArray(3) IsNot Nothing AndAlso
            resultsPanelsArray(4) IsNot Nothing Then
            PartialPathViewToolStripMenuItem.Checked = False
            DensityColorGridViewToolStripMenuItem.Checked = True
            DotPlotViewToolStripMenuItem.Checked = False
            GridViewToolStripMenuItem.Checked = False
            SequenceViewToolStripMenuItem.Checked = False
            If resultsGB.Controls.Contains(resultsPanelsArray(0)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(0))
            End If
            If resultsGB.Controls.Contains(resultsPanelsArray(1)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(1))
            End If
            If resultsGB.Controls.Contains(resultsPanelsArray(2)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(2))
            End If
            If resultsGB.Controls.Contains(resultsPanelsArray(3)) Then
                resultsGB.Controls.Remove(resultsPanelsArray(3))
            End If
            resultsGB.Controls.Add(resultsPanelsArray(4))
            orderByLabel.Visible = False
            orderByComboBox.Visible = False
            suboptimalFirstButton.Visible = False
            suboptimalLastButton.Visible = False
            suboptimalRightButton.Visible = False
            suboptimalLeftButton.Visible = False
            matchesGapsDCButton.Visible = True
            gapsOnlyDCButton.Visible = True
            matchesOnlyDCButton.Visible = True
            zoomToActualButton.Enabled = True
            zoomToFitButton.Enabled = True
            ZoomToFitToolStripMenuItem.Enabled = True
            ZoomToActualSizeToolStripMenuItem.Enabled = True
            If statResultsGB.HasChildren Then
                statResultsGB.Controls.Remove(statsPanel)
            End If
        End If
    End Sub
    Private Sub grid_RowPrePaint(ByVal sender As Object, ByVal e As DataGridViewRowPrePaintEventArgs)
        e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All)
        e.PaintHeader(DataGridViewPaintParts.Background Or _
                     DataGridViewPaintParts.Border Or _
                      DataGridViewPaintParts.Focus Or _
                      DataGridViewPaintParts.SelectionBackground)
        e.Handled = True
        Dim grid As DataGridView = CType(sender, DataGridView)
        Dim o As Object = grid.Rows(e.RowIndex).HeaderCell.Value
        Dim newformat As StringFormat = New StringFormat()
        newformat.FormatFlags = StringFormatFlags.NoWrap
        e.Graphics.DrawString(
            If(o IsNot Nothing, o.ToString(), ""),
            grid.Font,
            New SolidBrush(grid.RowHeadersDefaultCellStyle.ForeColor),
            New Rectangle(e.RowBounds.Left + 2,
                          e.RowBounds.Top + 4,
                          e.RowBounds.Left + (e.RowBounds.Size.Height - 8),
                          e.RowBounds.Top + (e.RowBounds.Size.Height - 8)), newformat)

    End Sub
    Private Sub partialPathGrid_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs)
        'what kind of line to draw?
        If e.RowIndex < 1 OrElse e.ColumnIndex < 1 OrElse currentResult Is Nothing Then
            Return
        End If
        e.Paint(e.ClipBounds, DataGridViewPaintParts.Border Or DataGridViewPaintParts.Background)
        If My.Settings.ViewFullTracebackGraph Then
            Dim i As Integer = e.RowIndex - 1
            Dim j As Integer = e.ColumnIndex - 1
            If i < currentResult.getTMatrix().Item(currentlyDisplayedAlignment).GetUpperBound(1) AndAlso
                currentResult.getTMatrix.Item(currentlyDisplayedAlignment)(j, i + 1) = 1 Then
                'vertical line
                e.Graphics.DrawLine(Pens.Black,
                                    e.CellBounds.X,
                                    e.CellBounds.Y,
                                    e.CellBounds.X,
                                    e.CellBounds.Y + e.CellBounds.Size.Height)
                e.Handled = True
            End If
            If j < currentResult.getTMatrix().Item(currentlyDisplayedAlignment).GetUpperBound(0) AndAlso
                currentResult.getTMatrix.Item(currentlyDisplayedAlignment)(j + 1, i) = 0 Then
                'horizontal line
                e.Graphics.DrawLine(Pens.Black,
                                    e.CellBounds.X,
                                    e.CellBounds.Y,
                                    e.CellBounds.X + e.CellBounds.Size.Width,
                                    e.CellBounds.Y)
                e.Handled = True
            End If
            If j < currentResult.getTMatrix().Item(currentlyDisplayedAlignment).GetUpperBound(0) AndAlso
                i < currentResult.getTMatrix().Item(currentlyDisplayedAlignment).GetUpperBound(1) AndAlso
                currentResult.getTMatrix().Item(currentlyDisplayedAlignment)(j + 1, i + 1) = 2 Then
                'diagonal line
                e.Graphics.DrawLine(Pens.Black,
                                    e.CellBounds.X,
                                    e.CellBounds.Y,
                                    e.CellBounds.X + e.CellBounds.Size.Width,
                                    e.CellBounds.Y + e.CellBounds.Size.Height)
                e.Handled = True
            End If
        Else
            Dim paintWhich As Integer = 0
            Dim i As Integer = e.ColumnIndex - 1
            Dim j As Integer = e.RowIndex - 1
            If i <= alignmentContainsPartialPathMatrix.GetUpperBound(0) AndAlso
                j + 1 <= alignmentContainsPartialPathMatrix.GetUpperBound(1) AndAlso
                alignmentContainsPartialPathMatrix(i, j + 1) AndAlso
                         j < currentResult.getTMatrix().Item(
                             currentlyDisplayedAlignment).GetUpperBound(1) AndAlso
                    currentResult.getTMatrix.Item(currentlyDisplayedAlignment)(i, j + 1) = 1 AndAlso
                paintWhich Mod 1000 < 100 Then
                paintWhich += 100
            End If
            If i + 1 <= alignmentContainsPartialPathMatrix.GetUpperBound(0) AndAlso
                j <= alignmentContainsPartialPathMatrix.GetUpperBound(1) AndAlso
                alignmentContainsPartialPathMatrix(i + 1, j) AndAlso
                             i < currentResult.getTMatrix().Item(
                                 currentlyDisplayedAlignment).GetUpperBound(0) AndAlso
                                currentResult.getTMatrix.Item(currentlyDisplayedAlignment)(
                                    i + 1, j) = 0 AndAlso
                            paintWhich Mod 100 < 10 Then
                paintWhich += 10
            End If
            If i + 1 <= alignmentContainsPartialPathMatrix.GetUpperBound(0) AndAlso
                j + 1 <= alignmentContainsPartialPathMatrix.GetUpperBound(1) AndAlso
                alignmentContainsPartialPathMatrix(i + 1, j + 1) AndAlso
     i < currentResult.getTMatrix().Item(currentlyDisplayedAlignment).GetUpperBound(0) AndAlso
        j < currentResult.getTMatrix().Item(currentlyDisplayedAlignment).GetUpperBound(1) AndAlso
        currentResult.getTMatrix.Item(currentlyDisplayedAlignment)(i + 1, j + 1) = 2 AndAlso
    paintWhich Mod 10 < 1 Then
                paintWhich += 1
            End If
            If paintWhich Mod 1000 >= 100 Then
                'vertical line
                e.Graphics.DrawLine(Pens.Black,
                                    e.CellBounds.X,
                                    e.CellBounds.Y,
                                    e.CellBounds.X,
                                    e.CellBounds.Y + e.CellBounds.Size.Height)
                e.Handled = True
            End If
            If paintWhich Mod 100 >= 10 Then
                'horizontal line
                e.Graphics.DrawLine(Pens.Black,
                                    e.CellBounds.X,
                                    e.CellBounds.Y,
                                    e.CellBounds.X + e.CellBounds.Size.Width,
                                    e.CellBounds.Y)
                e.Handled = True
            End If
            If paintWhich Mod 10 >= 1 Then
                'diagonal line
                e.Graphics.DrawLine(Pens.Black,
                                    e.CellBounds.X,
                                    e.CellBounds.Y,
                                    e.CellBounds.X + e.CellBounds.Size.Width,
                                    e.CellBounds.Y + e.CellBounds.Size.Height)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub partialPathGrid_RowPrePaint(ByVal sender As Object, ByVal e As DataGridViewRowPrePaintEventArgs)
        e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All)
        e.PaintHeader(DataGridViewPaintParts.Background Or _
                      DataGridViewPaintParts.Focus Or _
                      DataGridViewPaintParts.Border)
        e.Handled = True
        Dim grid As DataGridView = CType(sender, DataGridView)
        Dim o As Object = grid.Rows(e.RowIndex).HeaderCell.Value
        Dim newformat As StringFormat = New StringFormat()
        newformat.FormatFlags = StringFormatFlags.NoWrap
        e.Graphics.DrawString(
            If(o IsNot Nothing, o.ToString(), ""),
            grid.Font,
            New SolidBrush(grid.RowHeadersDefaultCellStyle.ForeColor),
            New Rectangle(e.RowBounds.Left + CInt(Math.Floor(e.RowBounds.Height / 2) - 6),
                          e.RowBounds.Top + CInt(Math.Floor(e.RowBounds.Height / 2) - 6),
                          e.RowBounds.Left + (e.RowBounds.Size.Height),
                          e.RowBounds.Top + (e.RowBounds.Size.Height)), newformat)

    End Sub
    Private Sub DisplaySequence1NumbersToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles DisplaySequence1NumbersToolStripMenuItem.Click
        My.Settings.DisplaySequence1Numbers = DisplaySequence1NumbersToolStripMenuItem.Checked
        displayAlignment(currentlyDisplayedAlignment)
    End Sub
    Private Sub DisplaySequence2NumbersToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles DisplaySequence2NumbersToolStripMenuItem.Click
        My.Settings.DisplaySequence2Numbers = DisplaySequence2NumbersToolStripMenuItem.Checked
        displayAlignment(currentlyDisplayedAlignment)
    End Sub
    Private Sub DimMismatchesToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles DimMismatchesToolStripMenuItem.Click
        My.Settings.DimMismatches = DimMismatchesToolStripMenuItem.Checked
        displayAlignment(currentlyDisplayedAlignment)
    End Sub
    Private Sub orderByComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles orderByComboBox.SelectedIndexChanged
        If currentlyDisplayedAlignment <> -1 Then
            Select Case orderByComboBox.SelectedItem.ToString
                Case "Score"
                    OrderByScoreToolStripMenuItem.Checked = True
                    OrderByNumberOfGapsToolStripMenuItem.Checked = False
                    OrderByNumberOfMatchesToolStripMenuItem.Checked = False
                    OrderByNumberOfMismatchesToolStripMenuItem.Checked = False
                    OrderByLengthToolStripMenuItem.Checked = False
                    currentResult.orderAlignmentsBy(Result.ORDER_TYPE.SCORE)
                Case "Length"
                    OrderByScoreToolStripMenuItem.Checked = False
                    OrderByNumberOfGapsToolStripMenuItem.Checked = False
                    OrderByNumberOfMatchesToolStripMenuItem.Checked = False
                    OrderByNumberOfMismatchesToolStripMenuItem.Checked = False
                    OrderByLengthToolStripMenuItem.Checked = True
                    currentResult.orderAlignmentsBy(Result.ORDER_TYPE.LENGTH)
                Case "Number of Gaps"
                    OrderByScoreToolStripMenuItem.Checked = False
                    OrderByNumberOfGapsToolStripMenuItem.Checked = True
                    OrderByNumberOfMatchesToolStripMenuItem.Checked = False
                    OrderByNumberOfMismatchesToolStripMenuItem.Checked = False
                    OrderByLengthToolStripMenuItem.Checked = False
                    currentResult.orderAlignmentsBy(Result.ORDER_TYPE.GAPS)
                Case "Number of Matches"
                    OrderByScoreToolStripMenuItem.Checked = False
                    OrderByNumberOfGapsToolStripMenuItem.Checked = False
                    OrderByNumberOfMatchesToolStripMenuItem.Checked = True
                    OrderByNumberOfMismatchesToolStripMenuItem.Checked = False
                    OrderByLengthToolStripMenuItem.Checked = False
                    currentResult.orderAlignmentsBy(Result.ORDER_TYPE.MATCHES)
                Case Else
                    OrderByScoreToolStripMenuItem.Checked = False
                    OrderByNumberOfGapsToolStripMenuItem.Checked = False
                    OrderByNumberOfMatchesToolStripMenuItem.Checked = False
                    OrderByNumberOfMismatchesToolStripMenuItem.Checked = True
                    OrderByLengthToolStripMenuItem.Checked = False
                    currentResult.orderAlignmentsBy(Result.ORDER_TYPE.MISMATCHES)
                    'mismatches
            End Select
            displayAlignment(0)
        End If
    End Sub
    Private Sub ViewFullTracebackGraphToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles ViewFullTracebackGraphToolStripMenuItem.Click
        My.Settings.ViewFullTracebackGraph = ViewFullTracebackGraphToolStripMenuItem.Checked
        If currentlyDisplayedAlignment <> -1 Then
            displayAlignment(currentlyDisplayedAlignment)
        End If
    End Sub
    Private Sub ShowGridLinesToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles ShowGridLinesToolStripMenuItem.Click
        My.Settings.ShowGridLinesPartialPath = ShowGridLinesToolStripMenuItem.Checked
        If resultsPanelsArray(2) IsNot Nothing Then
            'find grid
            For Each c As Control In resultsPanelsArray(2).Controls
                If c.Name = "resultsPartialPathGrid" Then
                    CType(c, DataGridView).GridColor = If(My.Settings.ShowGridLinesPartialPath,
                                                          Color.LightGray, Color.White)
                    CType(c, DataGridView).Refresh()
                End If
            Next
        End If
    End Sub
    Private Sub importSeq1Button_Click(sender As Object, e As EventArgs) Handles importSeq1Button.Click, Sequence1ToolStripMenuItem.Click
        Me.Enabled = False
        Dim fDialog As OpenFileDialog = New OpenFileDialog
        fDialog.Title = "Import Sequence One Dialog"
        fDialog.InitialDirectory = My.Application.Info.DirectoryPath
        fDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        fDialog.FilterIndex = 1
        fDialog.RestoreDirectory = True

        If fDialog.ShowDialog() = DialogResult.OK Then
            'parse text into sequence 1 box
            parseInto(fDialog.FileName, seq1Rtextbox)
        End If
        Me.Enabled = True
    End Sub
    Private Sub importSeq2Button_Click(sender As Object, e As EventArgs) Handles importSeq2Button.Click, Sequence2ToolStripMenuItem.Click
        Me.Enabled = False
        Dim fDialog As OpenFileDialog = New OpenFileDialog
        fDialog.Title = "Import Sequence Two Dialog"
        fDialog.InitialDirectory = My.Application.Info.DirectoryPath
        fDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        fDialog.FilterIndex = 1
        fDialog.RestoreDirectory = True

        If fDialog.ShowDialog() = DialogResult.OK Then
            'parse text into sequence 2 box
            parseInto(fDialog.FileName, seq2Rtextbox)
        End If
        Me.Enabled = True
    End Sub
    Private Sub DensityColorSimilarityMatchingToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles DensityColorSimilarityMatchingToolStripMenuItem.Click
        My.Settings.SequenceDensityColors = DensityColorSimilarityMatchingToolStripMenuItem.Checked
        If currentlyDisplayedAlignment <> -1 Then
            displayAlignment(currentlyDisplayedAlignment)
        End If
    End Sub
    Private Sub zoomToFitButton_CheckedChanged(sender As Object, e As EventArgs) Handles zoomToFitButton.CheckedChanged
        ZoomToFitToolStripMenuItem.Checked = zoomToFitButton.Checked
        ZoomToActualSizeToolStripMenuItem.Checked = Not zoomToFitButton.Checked
        If zoomToFitButton.Checked Then
            If resultsPanelsArray(0) IsNot Nothing Then
                For Each c As Control In resultsPanelsArray(0).Controls
                    If c.Name = "resultsPanelGrid" Then
                        Dim grid As DataGridView = CType(c, DataGridView)
                        grid.ColumnHeadersHeight = Math.Max(Math.Min(61,
                                                Math.Min(CInt(Math.Floor(
                                                         grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                           CInt(Math.Floor(
                                                            grid.Size.Height /
                                                            currentResult.getSequence2().Length - 1)))), 4)
                        grid.RowHeadersWidth = Math.Max(Math.Min(61,
                                                Math.Min(CInt(Math.Floor(
                                                         grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                           CInt(Math.Floor(
                                                            grid.Size.Height /
                                                            currentResult.getSequence2().Length - 1)))), 4)

                        For i As Integer = 0 To grid.RowCount - 1
                            grid.Rows(i).Height = Math.Max(Math.Min(61,
                                            Math.Min(CInt(Math.Floor(
                                                     grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                       CInt(Math.Floor(
                                                        grid.Size.Height /
                                                        currentResult.getSequence2().Length - 1)))), 4)
                        Next
                        For i As Integer = 0 To grid.ColumnCount - 1
                            grid.Columns(i).Width = Math.Max(Math.Min(61,
                                            Math.Min(CInt(Math.Floor(
                                                     grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                       CInt(Math.Floor(
                                                        grid.Size.Height /
                                                        currentResult.getSequence2().Length - 1)))), 4)
                        Next
                        Exit For
                    End If
                Next
            End If
            If resultsPanelsArray(2) IsNot Nothing Then
                'get grid
                For Each c As Control In resultsPanelsArray(2).Controls
                    If c.Name = "resultsPartialPathGrid" Then
                        Dim grid As DataGridView = CType(c, DataGridView)
                        grid.ColumnHeadersHeight = Math.Max(Math.Min(19,
                                                Math.Min(CInt(Math.Floor(
                                                         grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                           CInt(Math.Floor(
                                                            grid.Size.Height /
                                                            currentResult.getSequence2().Length - 1)))), 4)
                        grid.RowHeadersWidth = Math.Max(Math.Min(19,
                                                Math.Min(CInt(Math.Floor(
                                                         grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                           CInt(Math.Floor(
                                                            grid.Size.Height /
                                                            currentResult.getSequence2().Length - 1)))), 4)

                        For i As Integer = 0 To grid.RowCount - 1
                            grid.Rows(i).Height = Math.Max(Math.Min(19,
                                            Math.Min(CInt(Math.Floor(
                                                     grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                       CInt(Math.Floor(
                                                        grid.Size.Height /
                                                        currentResult.getSequence2().Length - 1)))), 4)
                        Next
                        For i As Integer = 0 To grid.ColumnCount - 1
                            grid.Columns(i).Width = Math.Max(Math.Min(19,
                                            Math.Min(CInt(Math.Floor(
                                                     grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                       CInt(Math.Floor(
                                                        grid.Size.Height /
                                                        currentResult.getSequence2().Length - 1)))), 4)
                        Next
                        Exit For
                    End If
                Next
            End If
            If resultsPanelsArray(3) IsNot Nothing Then
                'get grid
                For Each c As Control In resultsPanelsArray(3).Controls
                    If c.Name = "resultsDotPlotGrid" Then
                        Dim grid As DataGridView = CType(c, DataGridView)
                        grid.ColumnHeadersHeight = Math.Max(Math.Min(19,
                                                Math.Min(CInt(Math.Floor(
                                                         grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                           CInt(Math.Floor(
                                                            grid.Size.Height /
                                                            currentResult.getSequence2().Length - 1)))), 4)
                        grid.RowHeadersWidth = Math.Max(Math.Min(19,
                                                Math.Min(CInt(Math.Floor(
                                                         grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                           CInt(Math.Floor(
                                                            grid.Size.Height /
                                                            currentResult.getSequence2().Length - 1)))), 4)

                        For i As Integer = 0 To grid.RowCount - 1
                            grid.Rows(i).Height = Math.Max(Math.Min(19,
                                            Math.Min(CInt(Math.Floor(
                                                     grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                       CInt(Math.Floor(
                                                        grid.Size.Height /
                                                        currentResult.getSequence2().Length - 1)))), 4)
                        Next
                        For i As Integer = 0 To grid.ColumnCount - 1
                            grid.Columns(i).Width = Math.Max(Math.Min(19,
                                            Math.Min(CInt(Math.Floor(
                                                     grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                       CInt(Math.Floor(
                                                        grid.Size.Height /
                                                        currentResult.getSequence2().Length - 1)))), 4)
                        Next
                        Exit For
                    End If
                Next
            End If
            If resultsPanelsArray(4) IsNot Nothing Then
                'get grid
                For Each c As Control In resultsPanelsArray(4).Controls
                    If c.Name = "resultsDensityColorGrid" Then
                        Dim grid As DataGridView = CType(c, DataGridView)
                        grid.ColumnHeadersHeight = Math.Max(Math.Min(19,
                                                Math.Min(CInt(Math.Floor(
                                                         grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                           CInt(Math.Floor(
                                                            grid.Size.Height /
                                                            currentResult.getSequence2().Length - 1)))), 4)
                        grid.RowHeadersWidth = Math.Max(Math.Min(19,
                                                Math.Min(CInt(Math.Floor(
                                                         grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                           CInt(Math.Floor(
                                                            grid.Size.Height /
                                                            currentResult.getSequence2().Length - 1)))), 4)

                        For i As Integer = 0 To grid.RowCount - 1
                            grid.Rows(i).Height = Math.Max(Math.Min(19,
                                            Math.Min(CInt(Math.Floor(
                                                     grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                       CInt(Math.Floor(
                                                        grid.Size.Height /
                                                        currentResult.getSequence2().Length - 1)))), 4)
                        Next
                        For i As Integer = 0 To grid.ColumnCount - 1
                            grid.Columns(i).Width = Math.Max(Math.Min(19,
                                            Math.Min(CInt(Math.Floor(
                                                     grid.Size.Width / currentResult.getSequence1().Length - 1)),
                                                       CInt(Math.Floor(
                                                        grid.Size.Height /
                                                        currentResult.getSequence2().Length - 1)))), 4)
                        Next
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub zoomToActualButton_CheckedChanged(sender As Object, e As EventArgs) Handles zoomToActualButton.CheckedChanged
        ZoomToActualSizeToolStripMenuItem.Checked = zoomToActualButton.Checked
        ZoomToFitToolStripMenuItem.Checked = Not zoomToActualButton.Checked
        If zoomToActualButton.Checked Then
            If resultsPanelsArray(0) IsNot Nothing Then
                'get grid
                For Each c As Control In resultsPanelsArray(0).Controls
                    If c.Name = "resultsPanelGrid" Then
                        Dim grid As DataGridView = CType(c, DataGridView)
                        grid.ColumnHeadersHeight = 61
                        grid.RowHeadersWidth = 61

                        For i As Integer = 0 To grid.RowCount - 1
                            grid.Rows(i).Height = 61
                        Next
                        For i As Integer = 0 To grid.ColumnCount - 1
                            grid.Columns(i).Width = 61
                        Next
                        Exit For
                    End If
                Next
            End If
            If resultsPanelsArray(2) IsNot Nothing Then
                'get grid
                For Each c As Control In resultsPanelsArray(2).Controls
                    If c.Name = "resultsPartialPathGrid" Then
                        Dim grid As DataGridView = CType(c, DataGridView)
                        grid.ColumnHeadersHeight = 19
                        grid.RowHeadersWidth = 19

                        For i As Integer = 0 To grid.RowCount - 1
                            grid.Rows(i).Height = 19
                        Next
                        For i As Integer = 0 To grid.ColumnCount - 1
                            grid.Columns(i).Width = 19
                        Next
                        Exit For
                    End If
                Next
            End If
            If resultsPanelsArray(3) IsNot Nothing Then
                'get grid
                For Each c As Control In resultsPanelsArray(3).Controls
                    If c.Name = "resultsDotPlotGrid" Then
                        Dim grid As DataGridView = CType(c, DataGridView)
                        grid.ColumnHeadersHeight = 19
                        grid.RowHeadersWidth = 19

                        For i As Integer = 0 To grid.RowCount - 1
                            grid.Rows(i).Height = 19
                        Next
                        For i As Integer = 0 To grid.ColumnCount - 1
                            grid.Columns(i).Width = 19
                        Next
                        Exit For
                    End If
                Next
            End If
            If resultsPanelsArray(4) IsNot Nothing Then
                'get grid
                For Each c As Control In resultsPanelsArray(4).Controls
                    If c.Name = "resultsDensityColorGrid" Then
                        Dim grid As DataGridView = CType(c, DataGridView)
                        grid.ColumnHeadersHeight = 19
                        grid.RowHeadersWidth = 19

                        For i As Integer = 0 To grid.RowCount - 1
                            grid.Rows(i).Height = 19
                        Next
                        For i As Integer = 0 To grid.ColumnCount - 1
                            grid.Columns(i).Width = 19
                        Next
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub UseColorsToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles UseColorsToolStripMenuItem.Click
        My.Settings.DotPlotInColor = UseColorsToolStripMenuItem.Checked
        displayAlignment(currentlyDisplayedAlignment)
    End Sub
    Private Sub ShowGridLinesToolStripMenuItemDotPlot_CheckedChanged(sender As Object, e As EventArgs) Handles ShowGridLinesToolStripMenuItemDotPlot.Click
        My.Settings.ShowGridLinesDotPlot = ShowGridLinesToolStripMenuItemDotPlot.Checked
        If resultsPanelsArray(3) IsNot Nothing Then
            'find grid
            For Each c As Control In resultsPanelsArray(3).Controls
                If c.Name = "resultsDotPlotGrid" Then
                    CType(c, DataGridView).GridColor = If(My.Settings.ShowGridLinesDotPlot,
                                                          Color.LightGray, Color.White)
                    CType(c, DataGridView).Refresh()
                End If
            Next
        End If
    End Sub
    Private Sub ShowGridLinesToolStripMenuItemDensityColor_CheckedChanged(sender As Object, e As EventArgs) Handles ShowGridLinesToolStripMenuItemDensityColor.Click
        My.Settings.ShowGridLinesDensityColor = ShowGridLinesToolStripMenuItemDensityColor.Checked
        displayAlignment(currentlyDisplayedAlignment)
    End Sub
    Private Sub ViewScoringMatricesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewScoringMatricesToolStripMenuItem.Click
        Me.Enabled = False
        Dim scoringMatrixF As scoringMatrixViewer = New scoringMatrixViewer()
        scoringMatrixF.passData(Me, aminoAcidList)
        scoringMatrixF.Show()
    End Sub
    Private Sub ZoomToActualSizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomToActualSizeToolStripMenuItem.Click
        ZoomToFitToolStripMenuItem.Checked = False
        ZoomToActualSizeToolStripMenuItem.Checked = True
        zoomToActualButton.Checked = True
    End Sub
    Private Sub ZoomToFitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomToFitToolStripMenuItem.Click
        zoomToFitButton.Checked = True
        ZoomToActualSizeToolStripMenuItem.Checked = False
        ZoomToFitToolStripMenuItem.Checked = True
    End Sub
    Private Sub matchesGapsDCButton_CheckedChanged(sender As Object, e As EventArgs) Handles matchesGapsDCButton.CheckedChanged
        displayAlignment(currentlyDisplayedAlignment)
        MatchesAndGapsToolStripMenuItem.Checked = True
        GapsOnlyToolStripMenuItem.Checked = False
        MatchesOnlyToolStripMenuItem.Checked = False
    End Sub
    Private Sub gapsOnlyDCButton_CheckedChanged(sender As Object, e As EventArgs) Handles gapsOnlyDCButton.CheckedChanged
        displayAlignment(currentlyDisplayedAlignment)
        MatchesAndGapsToolStripMenuItem.Checked = False
        GapsOnlyToolStripMenuItem.Checked = True
        MatchesOnlyToolStripMenuItem.Checked = False
    End Sub
    Private Sub matchesOnlyDCButton_CheckedChanged(sender As Object, e As EventArgs) Handles matchesOnlyDCButton.CheckedChanged
        displayAlignment(currentlyDisplayedAlignment)
        MatchesAndGapsToolStripMenuItem.Checked = False
        GapsOnlyToolStripMenuItem.Checked = False
        MatchesOnlyToolStripMenuItem.Checked = True
    End Sub
    Private Sub UseWindowingToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles UseWindowingToolStripMenuItem.Click
        My.Settings.UseWindowingForDotPlot = UseWindowingToolStripMenuItem.Checked
        displayAlignment(currentlyDisplayedAlignment)
    End Sub
    Private Sub SimpleSequenceLineViewToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles SimpleSequenceLineViewToolStripMenuItem.Click
        My.Settings.SimpleSequenceLineView = SimpleSequenceLineViewToolStripMenuItem.Checked
        displayAlignment(currentlyDisplayedAlignment)
    End Sub
    Private Sub compareMultipleAlignmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles compareMultipleAlignmentsToolStripMenuItem.Click
        Dim compareAlignmentsForm As comparativeChartForm = New comparativeChartForm()
        compareResult(0) = currentResult
        compareAlignmentsForm.passParameters(Me, compareResult)
        Me.Enabled = False
        compareAlignmentsForm.Visible = True
    End Sub
    Private Sub SaveAlignmentLAVTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAlignmentLAVTToolStripMenuItem.Click
        Me.Enabled = False
        Dim fDialog As SaveFileDialog = New SaveFileDialog
        fDialog.Title = "Local Alignment Visualization Tool Result Save Dialog"
        fDialog.InitialDirectory = My.Application.Info.DirectoryPath
        fDialog.Filter = "Local Alignment Visualization Tool Result Files (*.LAVTR)|*.LAVTR|All Files (*.*)|*.*"
        fDialog.FilterIndex = 1
        fDialog.RestoreDirectory = True
        fDialog.FileName = currentResult.getName()

        Dim result As DialogResult = fDialog.ShowDialog()
        If result = DialogResult.OK Then
            'parse text into sequence 1 box
            currentResult.saveResult(fDialog.FileName, Me)
        ElseIf result = Windows.Forms.DialogResult.Cancel Then
            Me.Enabled = True
        End If
    End Sub
    Private Sub MatchesOnlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MatchesOnlyToolStripMenuItem.Click
        matchesOnlyDCButton.PerformClick()
    End Sub
    Private Sub MatchesAndGapsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MatchesAndGapsToolStripMenuItem.Click
        matchesGapsDCButton.PerformClick()
    End Sub
    Private Sub GapsOnlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GapsOnlyToolStripMenuItem.Click
        gapsOnlyDCButton.PerformClick()
    End Sub
    Private Sub matchesOnlyDCButton_VisibleChanged(sender As Object, e As EventArgs) Handles matchesOnlyDCButton.VisibleChanged
        MatchesAndGapsToolStripMenuItem.Enabled = matchesOnlyDCButton.Enabled
        MatchesOnlyToolStripMenuItem.Enabled = matchesOnlyDCButton.Enabled
        GapsOnlyToolStripMenuItem.Enabled = matchesOnlyDCButton.Enabled
    End Sub
    Private Sub GridViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GridViewToolStripMenuItem.Click
        If GridViewToolStripMenuItem.Checked Then
            viewCombobox.SelectedItem = "Grid View"
        End If
        PartialPathViewToolStripMenuItem.Checked = False
        DensityColorGridViewToolStripMenuItem.Checked = False
        DotPlotViewToolStripMenuItem.Checked = False
        GridViewToolStripMenuItem.Checked = True
        SequenceViewToolStripMenuItem.Checked = False
    End Sub
    Private Sub SequenceViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SequenceViewToolStripMenuItem.Click
        If SequenceViewToolStripMenuItem.Checked Then
            viewCombobox.SelectedItem = "Sequence View"
        End If
        PartialPathViewToolStripMenuItem.Checked = False
        DensityColorGridViewToolStripMenuItem.Checked = False
        DotPlotViewToolStripMenuItem.Checked = False
        GridViewToolStripMenuItem.Checked = False
        SequenceViewToolStripMenuItem.Checked = True
    End Sub
    Private Sub PartialPathViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartialPathViewToolStripMenuItem.Click
        If PartialPathViewToolStripMenuItem.Checked Then
            viewCombobox.SelectedItem = "Partial Path View"
        End If
        PartialPathViewToolStripMenuItem.Checked = True
        DensityColorGridViewToolStripMenuItem.Checked = False
        DotPlotViewToolStripMenuItem.Checked = False
        GridViewToolStripMenuItem.Checked = False
        SequenceViewToolStripMenuItem.Checked = False
    End Sub
    Private Sub DotPlotViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DotPlotViewToolStripMenuItem.Click
        If DotPlotViewToolStripMenuItem.Checked Then
            viewCombobox.SelectedItem = "Dot Plot View"
        End If
        PartialPathViewToolStripMenuItem.Checked = False
        DensityColorGridViewToolStripMenuItem.Checked = False
        DotPlotViewToolStripMenuItem.Checked = True
        GridViewToolStripMenuItem.Checked = False
        SequenceViewToolStripMenuItem.Checked = False
    End Sub
    Private Sub DensityColorGirdViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DensityColorGridViewToolStripMenuItem.Click
        If DensityColorGridViewToolStripMenuItem.Checked Then
            viewCombobox.SelectedItem = "Density Color View"
        End If
        PartialPathViewToolStripMenuItem.Checked = False
        DensityColorGridViewToolStripMenuItem.Checked = True
        DotPlotViewToolStripMenuItem.Checked = False
        GridViewToolStripMenuItem.Checked = False
        SequenceViewToolStripMenuItem.Checked = False
    End Sub
    Private Sub OrderByScoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderByScoreToolStripMenuItem.Click
        If OrderByScoreToolStripMenuItem.Checked Then
            orderByComboBox.SelectedItem = "Score"
        End If
        OrderByScoreToolStripMenuItem.Checked = True
        OrderByNumberOfGapsToolStripMenuItem.Checked = False
        OrderByNumberOfMatchesToolStripMenuItem.Checked = False
        OrderByNumberOfMismatchesToolStripMenuItem.Checked = False
        OrderByLengthToolStripMenuItem.Checked = False
    End Sub
    Private Sub OrderByLengthToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderByLengthToolStripMenuItem.Click
        If OrderByLengthToolStripMenuItem.Checked Then
            orderByComboBox.SelectedItem = "Length"
        End If
        OrderByScoreToolStripMenuItem.Checked = False
        OrderByNumberOfGapsToolStripMenuItem.Checked = False
        OrderByNumberOfMatchesToolStripMenuItem.Checked = False
        OrderByNumberOfMismatchesToolStripMenuItem.Checked = False
        OrderByLengthToolStripMenuItem.Checked = True
    End Sub
    Private Sub OrderByNumberOfGapsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderByNumberOfGapsToolStripMenuItem.Click
        If OrderByNumberOfGapsToolStripMenuItem.Checked Then
            orderByComboBox.SelectedItem = "Number of Gaps"
        End If
        OrderByScoreToolStripMenuItem.Checked = False
        OrderByNumberOfGapsToolStripMenuItem.Checked = True
        OrderByNumberOfMatchesToolStripMenuItem.Checked = False
        OrderByNumberOfMismatchesToolStripMenuItem.Checked = False
        OrderByLengthToolStripMenuItem.Checked = False
    End Sub
    Private Sub OrderByNumberOfMatchesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderByNumberOfMatchesToolStripMenuItem.Click
        If OrderByNumberOfMatchesToolStripMenuItem.Checked Then
            orderByComboBox.SelectedItem = "Number of Matches"
        End If
        OrderByScoreToolStripMenuItem.Checked = False
        OrderByNumberOfGapsToolStripMenuItem.Checked = False
        OrderByNumberOfMatchesToolStripMenuItem.Checked = True
        OrderByNumberOfMismatchesToolStripMenuItem.Checked = False
        OrderByLengthToolStripMenuItem.Checked = False
    End Sub
    Private Sub OrderByNumberOfMismatchesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderByNumberOfMismatchesToolStripMenuItem.Click
        If OrderByNumberOfMismatchesToolStripMenuItem.Checked Then
            orderByComboBox.SelectedItem = "Number of Mismatches"
        End If
        OrderByScoreToolStripMenuItem.Checked = False
        OrderByNumberOfGapsToolStripMenuItem.Checked = False
        OrderByNumberOfMatchesToolStripMenuItem.Checked = False
        OrderByNumberOfMismatchesToolStripMenuItem.Checked = True
        OrderByLengthToolStripMenuItem.Checked = False
    End Sub
    Private Sub orderByComboBox_VisibleChanged(sender As Object, e As EventArgs) Handles orderByComboBox.VisibleChanged
        OrderByScoreToolStripMenuItem.Enabled = orderByComboBox.Visible
        OrderByNumberOfGapsToolStripMenuItem.Enabled = orderByComboBox.Visible
        OrderByNumberOfMatchesToolStripMenuItem.Enabled = orderByComboBox.Visible
        OrderByNumberOfMismatchesToolStripMenuItem.Enabled = orderByComboBox.Visible
        OrderByLengthToolStripMenuItem.Enabled = orderByComboBox.Visible
    End Sub
    Private Sub LoadAlignmentLAVTRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadAlignmentLAVTRToolStripMenuItem.Click
        If unsavedResult Then
            Dim askResponse As DialogResult = MessageBox.Show("There are unsaved changes. Would you like to save first?",
                                                   "Save Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
            If askResponse = Windows.Forms.DialogResult.No Then
                If currentResult IsNot Nothing AndAlso currentResult.workerIsWorking Then
                    'cancel and wait
                    currentResult.passMainForm(Me)
                    currentResult.setCloseAfterCancel(False)
                    currentResult.setLoadAfterCancel(True)
                    currentResult.cancelWorker()
                Else
                    loadFile()
                End If
            ElseIf askResponse = Windows.Forms.DialogResult.Yes Then
                If currentResult IsNot Nothing Then
                    currentResult.passMainForm(Me)
                    currentResult.setCloseAfterSave(False)
                    currentResult.setLoadAfterSave(True)
                End If
                SaveAlignmentLAVTToolStripMenuItem.PerformClick()
            End If
        Else
            If currentResult IsNot Nothing AndAlso currentResult.workerIsWorking Then
                'cancel and wait
                currentResult.passMainForm(Me)
                currentResult.setCloseAfterCancel(False)
                currentResult.setLoadAfterCancel(True)
                currentResult.cancelWorker()
            Else
                loadFile()
            End If
        End If
    End Sub
    Private Sub SaveScoringMatrixLAVTSMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveScoringMatrixLAVTSMToolStripMenuItem.Click
        Me.Enabled = False
        Dim fDialog As SaveFileDialog = New SaveFileDialog
        fDialog.Title = "Local Alignment Visualization Tool Scoring Matrix Save Dialog"
        fDialog.InitialDirectory = My.Application.Info.DirectoryPath
        fDialog.Filter = "Local Alignment Visualization Tool Scoring Matrix Files (*.LAVTSM)|*.LAVTSM|All Files (*.*)|*.*"
        fDialog.FilterIndex = 1
        fDialog.RestoreDirectory = True
        fDialog.FileName() = getMatrixFileName()

        Dim result As DialogResult = fDialog.ShowDialog()
        If result = DialogResult.OK Then
            saveMatrix(fDialog.FileName)
        End If
        Me.Enabled = True
    End Sub
    Private Sub LoadScoringMatrixLAVTSMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadScoringMatrixLAVTSMToolStripMenuItem.Click
        If unsavedMatrix Then
            Dim askResponse As DialogResult = MessageBox.Show("There are unsaved changes. Would you like to save first?",
                                                   "Save Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
            If askResponse = Windows.Forms.DialogResult.No Then
                loadMatrix()
            ElseIf askResponse = Windows.Forms.DialogResult.Yes Then
                SaveScoringMatrixLAVTSMToolStripMenuItem.PerformClick()
            End If
        Else
            loadMatrix()
        End If
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Me.Enabled = False
        Dim about As aboutBox = New aboutBox()
        about.passMainForm(Me)
        about.Visible = True
    End Sub
    Private Sub ViewSourcesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewSourcesToolStripMenuItem.Click
        'next to implement
        Dim pdfView As sourceViewer = New sourceViewer()
        Me.Enabled = False
        pdfView.passParameters(Me)
        pdfView.Visible = True
    End Sub
    Private Sub HelpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem1.Click
        'pull up window with documentation
        'next to implement
        Dim pdfView As helpViewer = New helpViewer()
        Me.Enabled = False
        pdfView.passParameters(Me)
        pdfView.Visible = True
    End Sub
End Class