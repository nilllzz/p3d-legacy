﻿Namespace Items.XItems

    Public Class XSpDef

        Inherits Item

        Public Sub New()
            MyBase.New("X Sp. Def", 350, ItemTypes.BattleItems, 50, 1, 0, New Rectangle(144, 192, 24, 24), "An item that boosts the Sp. Def stat of a Pokémon during a battle. It wears off once the Pokémon is withdrawn.")

            Me._canBeUsed = False
            Me._canBeUsedInBattle = True
            Me._canBeTraded = True
            Me._canBeHold = True

            Me._requiresPokemonSelectInBattle = False
        End Sub

        Public Overrides Function UseOnPokemon(PokeIndex As Integer) As Boolean
            Dim foundBattleScreen As Boolean = True
            Dim s As Screen = Core.CurrentScreen
            While s.Identification <> Screen.Identifications.BattleScreen
                s = s.PreScreen
                If s.PreScreen Is Nothing Then
                    foundBattleScreen = False
                    Exit While
                End If
            End While

            If foundBattleScreen = True Then
                Dim p As Pokemon = CType(s, BattleSystem.BattleScreen).OwnPokemon

                If p.StatSpDefense < 6 Then
                    p.StatSpDefense += 1

                    Screen.TextBox.Show("Boosted " & p.GetDisplayName() & "'s~Special Defense!" & RemoveItem(), {}, False, False)
                    PlayerStatistics.Track("[53]Status booster used", 1)

                    Return True
                End If

                Screen.TextBox.Show("Cannot boost~ " & p.GetDisplayName() & "'s Special Defense!", {}, False, False)
                Return False
            Else
                Logger.Log(Logger.LogTypes.Warning, "XSpDef.vb: Used outside of battle environment!")
                Return False
            End If
        End Function

    End Class

End Namespace