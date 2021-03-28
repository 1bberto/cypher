#Cipher

Codigo tem como objetivo testar os conhecimentos com ***LinkedList***, que neste caso teve que ser implementada de maneira manual.
Uma vez que o dotnet não entrega uma LinkedList com a capacidade de ser circular.

O objetivo do algoritmo é obter uma string e converter ela em outra string (Criptografar os dados), e tambem receber um numero inteiro que sera o resposavel por dizer a quantidade de saltos que o caracter deve ser saltado para trás em caso de criptografia, e para frente em caso de decriptografia.

Utilizando a tabela `ASCII` fica mais simples de resolver este tipo de problema.

## Exemplo da funcao de criptografia:
texto: `VTAOG`

saltos: `2`

texto criptografado = `TRYME`

Explicação:
|Letra|Salto|Resultado|
|---|---|---|
|**V** (86)|-2|**T** (84)|
|**T** (84)|-2|**R** (82)|
|**A** (65)|-2|**Y** (89) -- neste caso como nao existe nada antes do A voltamos para o Z(90)
|**O** (79)|-2|**M** (77)|
|**G** (71)|-2|**E** (69)|

## Exemplo da função de decriptografia

texto: `JULUDI`

saltos: `12`

texto decriptografado = `VGXGPU`

Explicação:
|Letra|Salto|Resultado|
|---|---|---|
|**J** (74)|+12|**V** (86)|
|**U** (85)|+12|**G** (71) -- neste caso a soma vai passar do Z(90) ao passar do Z(90) voltamos para o A(65)|
|**L** (76)|+12|**X** (88)| 
|**U** (85)|+12|**G** (71) -- neste caso a soma vai passar do Z(90) ao passar do Z(90) voltamos para o A(65)|
|**D** (68)|+12|**P** (80)|
|**I** (73)|+12|**U** (85)|

## Solução 

Inicialmente temos que criar uma LinkedList

```csharp
public class LinkedList<T> where T : struct
{
    public LinkedListNode<T> Head { get; private set; }
    public LinkedListNode<T> Tail { get; private set; }
    public int Count { get; private set; } = 0;
   
    //Adicionar um item ao final da Lista
    public void Append(T value)
    {
        var current = Head;

        while (current?.Next != null)
        {
            current = current.Next;
        }

        var newNode = new LinkedListNode<T>(value, current);

        if (current != null)
        {
            current.Next = newNode;
        }
        else
        {
            Head = newNode;
        }

        Tail = newNode;

        Count++;
    }
    
    //Adicionar um item no começo da lista
    public void Prepend(T value)
    {
        var newHead = new LinkedListNode<T>(value)
        {
            Next = Head
        };

        Head.Previous = newHead;

        Head = newHead;

        Count++;
    }
    
    //Remover um item da lista
    public void RemoveWithValue(T data)
    {
        if (Head == null)
        {
            return;
        }

        if (Head == data)
        {
            Head = Head.Next;
            Count--;
            return;
        }

        var currentNode = Head;

        while (currentNode.Next != null)
        {
            if (currentNode.Next == data)
            {
                currentNode.Next = currentNode.Next.Next;
                Count--;
                return;
            }

            currentNode = currentNode.Next;
        }
    }
    
    //Fazer a referencia circular na lista, onde a Tail se une com a Head (sim ficou estranha esta parte), mas fazer o que
    public void Join()
    {
        Tail.Next = Head;

        Head.Previous = Tail;
    }

    //Procurar Primeiro nó com valor igual a value na lista
    public LinkedListNode<T> FindItem(T value)
    {
        var internalCounter = 0;
        var current = Head;
        while (current?.Next != null)
        {
            if (current == value)
            {
                return current;
            }

            current = current.Next;

            internalCounter++;

            if (internalCounter > Count)
            {
                break;
            }
        }

        return null;
    }
}
```

e tambem um LinkedListNode

```csharp
public class LinkedListNode<T> where T : struct
{
    public LinkedListNode<T> Next { get; set; }
    public LinkedListNode<T> Previous { get; set; }
    public T Value { get; set; }

    public LinkedListNode(T value)
    {
        Value = value;
    }

    public LinkedListNode(T value, LinkedListNode<T> previous)
    {
        Value = value;
        Previous = previous;
    }

    /*
    * Existe mais codigo abaixo, porem ficaria muita coisa para ficar dentro do read-me 😎
    */
}
```

O bloco de solução do codigo se encontra dentro do arquivo **Cipher.cs**

## Conciderações finais
E sim existem outras maneiras de resolver este algoritmo, sem usar LinkedList, mas a ideia principal foi testar os conhecimentos
para a criação de LinkedList Circulares
