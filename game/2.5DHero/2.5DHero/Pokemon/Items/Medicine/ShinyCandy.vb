﻿Namespace Items.Medicine

    ''' <summary>
    ''' Not in the game...
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ShinyCandy

        Inherits Item

        Public Sub New()
            MyBase.New("Shiny Candy", 4800, ItemTypes.Medicine, 501, 1, 1, New Rectangle(96, 240, 24, 24), "This mysterious candy sparkles when unwrapped. It attracts all sorts of Pokémon.")

            Me._canBeUsed = True
            Me._canBeUsedInBattle = False
            Me._canBeTraded = True
            Me._canBeHold = True
        End Sub

        Public Overrides Sub Use()
            Core.SetScreen(New ChoosePokemonScreen(Core.CurrentScreen, Me, AddressOf Me.UseOnPokemon, "Use " & Me.Name, True))
        End Sub

        Public Overrides Function UseOnPokemon(ByVal PokeIndex As Integer) As Boolean
            Dim p As Pokemon = Core.Player.Pokemons(PokeIndex)

            p.IsShiny = Not p.IsShiny

            SoundManager.PlaySound("single_heal", False)
            Screen.TextBox.Show("The Pokémon sparkled." & RemoveItem())
            PlayerStatistics.Track("[17]Medicine Items used", 1)

            Return True
        End Function

    End Class

End Namespace