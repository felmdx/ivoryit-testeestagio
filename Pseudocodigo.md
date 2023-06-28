# Logica utilizada na implementação

    Enquanto status do jogo for 0:
        Converte string para matriz, sendo -1 casas fechadas

        Se o valor da casa central for igual ao número de casas fechadas:
            Marca a casa como -2 (flag para bomba)
        Se não:
            Ignora a casa
        
        Percorre a matriz:
            Se a casa tiver valor maior ou igual a 1:
                Se a quantidade de casas fechadas ao redor da casa central é maior que a quantidade de bombas e se a quantidade de bombas é igual ao seu valor:
                    Abre a casa
                Se não:
                    Não faz nada
            Se não:
                Ignora a casa