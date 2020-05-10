#O que é?
=====================
Se trata de um projeto com algumas classes que visam encapsular as resposta de um método.

# Para que isso?
Tornar os métodos de uma aplicação honestos quando a sua responsabilidade e limitações é um dos desafios, quanto se tenta construir uma aplicação de fácil manutenção.

Chamar um método com a  certeza de que ele não vai te retornar NULL quando "promete" te retornar um objeto específico, parece até não existir.

Retornar NULL quando não é possível realizar uma operação, é um erro. E como resolver isso? Encapsulando a resposta.

Um método de repositório que promete retornar um Produto, por exemplo, para qualquer Id que você informe, é um método mentiroso, pois, ele não terá uma correspondência para qualquer Id que ele receba. Nesse caso,  o correto seria definir o retorno como um Maybe<Produto>.

O que muda então?

Quando o método retornar um Maybe (Talvez), fica claro para o chamador que ele precisa verificar o retorno do método, antes de "sair" trabalhando com ele. Segue um exemplo.

```
public interface ProductRepository
{
    Task<Maybe<Product>> FindAsync(int id);
}
```
O uso poderia ser algo como:

```
var product = await ProductRepository.FindAsync(1);

if (!product.HasValue)
  return response.WithBusinessError("id", $"Produto com o id '{id}' não encontrado.");
  
```
