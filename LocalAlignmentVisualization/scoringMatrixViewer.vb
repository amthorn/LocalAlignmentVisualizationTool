'Author: Avery Thorn
'Program: A local alignment visualization tool
'Date: 10/16/2015

Option Strict On
Option Infer Off
Option Explicit On

Public Class scoringMatrixViewer

    Private main As mainForm
    Private aminoAcidList As Char()
    Private currentMatrix As Integer = 0
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
    Private Sub scoringMatrixViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        displayMatrix(DEFAULT_MATRIX)
        topLabel.Text = "Scoring Matrix Viewer: DEFAULT"

        Dim PAMProbMat As Double(,) = getPAMProbMat()
    End Sub
    Private Function getPAM(ByVal n As Integer) As Double(,)
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
    End Function
    Private Function getPAMProbMat() As Double(,)
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
    End Function
    Private Sub displayMatrix(ByVal b As Double(,))
        matrixDGV.ColumnCount = 0
        'initialize matrix properly
        matrixDGV.ColumnCount = aminoAcidList.Length
        matrixDGV.RowHeadersWidth = 45
        For i As Integer = 0 To aminoAcidList.Length - 1
            matrixDGV.Columns(i).Name = aminoAcidList(i)
            matrixDGV.Columns(i).Width = 45
            matrixDGV.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        For i As Integer = 0 To aminoAcidList.Length - 1
            Dim currRow As DataGridViewRow = New DataGridViewRow()
            currRow.HeaderCell.Value = CStr(aminoAcidList(i))
            matrixDGV.Rows.Add(currRow)
        Next

        'get largest value as threshold
        Dim threshold As Double = largestValueOf(b)
        Dim minimum As Double = smallestValueOf(b)
        If threshold = Double.MinValue Then
            threshold = 1
        End If
        If minimum = Double.MaxValue Then
            minimum = 1
        End If
        threshold -= minimum


        'show matrix b
        For i As Integer = 0 To matrixDGV.Columns.Count - 1
            For j As Integer = 0 To matrixDGV.Rows.Count - 1
                If b.GetUpperBound(0) >= i AndAlso b.GetUpperBound(1) >= j Then
                    matrixDGV.Item(i, j).Value = Math.Round(b(i, j), 0)
                    Dim c As Integer = CInt(255 * ((b(j, i) - minimum) / threshold))
                    matrixDGV.Rows(i).Cells(j).Style.BackColor = System.Drawing.Color.FromArgb(255 - c, 255, 255 - c)
                Else
                    matrixDGV.Item(i, j).Value = "Er"
                    matrixDGV.Rows(i).Cells(j).Style.BackColor = Color.Red
                End If
            Next
        Next
    End Sub
    Private Function matrixPower(ByVal p As Integer, m As Double(,)) As Double(,)
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
    End Function
    Private Function largestValueOf(ByRef b As Double(,)) As Double
        Dim currMax As Double = Double.MinValue
        For Each i As Double In b
            If i > currMax Then
                currMax = i
            End If
        Next
        Return currMax
    End Function
    Private Function smallestValueOf(ByRef b As Double(,)) As Double
        Dim currMin As Double = Double.MaxValue
        For Each i As Double In b
            If i < currMin Then
                currMin = i
            End If
        Next
        Return currMin
    End Function
    Public Sub passData(ByRef m As mainForm, AAList As Char())
        main = m
        aminoAcidList = AAList
    End Sub
    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        'enable main form
        main.Enabled = True

        'close this form
        Me.Close()
    End Sub
    Private Sub nextButton_Click(sender As Object, e As EventArgs) Handles nextButton.Click
        Select Case currentMatrix
            Case 0
                displayMatrix(BLOSUM45)
                updateButton.Enabled = False
                pamNumTextbox.Enabled = False
                topLabel.Text = "Scoring Matrix Viewer: BLOSUM45"
                currentMatrix += 1
            Case 1
                displayMatrix(BLOSUM62)
                updateButton.Enabled = False
                pamNumTextbox.Enabled = False
                topLabel.Text = "Scoring Matrix Viewer: BLOSUM62"
                currentMatrix += 1
            Case 2
                displayMatrix(BLOSUM80)
                updateButton.Enabled = False
                pamNumTextbox.Enabled = False
                topLabel.Text = "Scoring Matrix Viewer: BLOSUM80"
                currentMatrix += 1
            Case 3
                displayMatrix(getPAM(1))
                pamNumTextbox.Text = "1"
                updateButton.Enabled = True
                pamNumTextbox.Enabled = True
                topLabel.Text = "Scoring Matrix Viewer: PAM1"
                currentMatrix += 1
            Case Else
                displayMatrix(DEFAULT_MATRIX)
                updateButton.Enabled = False
                pamNumTextbox.Enabled = False
                topLabel.Text = "Scoring Matrix Viewer: DEFAULT"
                currentMatrix -= 4
        End Select
    End Sub
    Private Sub previousButton_Click(sender As Object, e As EventArgs) Handles previousButton.Click
        Select Case currentMatrix
            Case 0
                displayMatrix(getPAM(1))
                updateButton.Enabled = True
                pamNumTextbox.Enabled = True
                pamNumTextbox.Text = "1"
                topLabel.Text = "Scoring Matrix Viewer: PAM1"
                currentMatrix += 4
            Case 1
                displayMatrix(DEFAULT_MATRIX)
                updateButton.Enabled = False
                pamNumTextbox.Enabled = False
                topLabel.Text = "Scoring Matrix Viewer: DEFAULT"
                currentMatrix -= 1
            Case 2
                displayMatrix(BLOSUM45)
                updateButton.Enabled = False
                pamNumTextbox.Enabled = False
                topLabel.Text = "Scoring Matrix Viewer: BLOSUM45"
                currentMatrix -= 1
            Case 3
                displayMatrix(BLOSUM62)
                updateButton.Enabled = False
                pamNumTextbox.Enabled = False
                topLabel.Text = "Scoring Matrix Viewer: BLOSUM62"
                currentMatrix -= 1
            Case Else
                displayMatrix(BLOSUM80)
                updateButton.Enabled = False
                pamNumTextbox.Enabled = False
                topLabel.Text = "Scoring Matrix Viewer: BLOSUM80"
                currentMatrix -= 1
        End Select
    End Sub
    Private Sub pamNumTextbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles pamNumTextbox.KeyPress
        'numbers only
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso
            e.KeyChar <> ControlChars.Back Then
            e.Handled = True
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
            warningToolTip.Show("You may only enter numbers!", pamNumTextbox.Parent,
                              New Point(CInt(pamNumTextbox.Location.X + pamNumTextbox.Width / 2),
                                        pamNumTextbox.Location.Y - 50), 3000)
        End If
    End Sub
    Private Sub updateButton_Click(sender As Object, e As EventArgs) Handles updateButton.Click
        Dim parsedText As Integer
        Integer.TryParse(pamNumTextbox.Text, parsedText)
        If parsedText > 1000 OrElse parsedText < 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
            warningToolTip.Show("Your number must be between 1 and 1000!", pamNumTextbox.Parent,
                              New Point(CInt(pamNumTextbox.Location.X + pamNumTextbox.Width / 2),
                                        pamNumTextbox.Location.Y - 50), 3000)
        Else
            displayMatrix(getPAM(parsedText))
            topLabel.Text = "Scoring Matrix Viewer: PAM" & parsedText
        End If
    End Sub
End Class