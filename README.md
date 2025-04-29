# WiseCart - Seu Assistente Inteligente de Compras no Supermercado

## 📱 Visão Geral
O WiseCart é um aplicativo móvel que transforma a experiência de compras em supermercados, permitindo que os consumidores:
- Escaneiem produtos
- Registrem quantidades e valores
- Acompanhem o total gasto em tempo real
- Mantenham histórico de suas compras

## ✨ Funcionalidades Principais
- **Autenticação Segura**: Login de usuário com proteção de dados
- **Scanner de Produtos**: Leitura de códigos de barras para identificação automática
- **Gestão de Itens**:
  - Adição manual de quantidade e valor unitário
  - Atualização em tempo real do valor total
- **Lista Organizada**: Visualização clara de todos os produtos escaneados
- **Cálculo Automático**: Soma instantânea dos valores dos produtos

## 🛠 Arquitetura e Tecnologias

### Backend
- **.NET 9** com Clean Architecture
- **PostgreSQL** para armazenamento de dados
- **ASP.NET Core MVC** para protótipo web

### Frontend Mobile
- **React Native** (Android)
- Componentes modernos e intuitivos
- Integração perfeita com a API

### Infraestrutura
- Swagger para documentação de API

## 📂 Estrutura do Projeto
```
WiseCart/
├── WiseCart.API/          	# Camada de API
├── WiseCart.Application/  	# Casos de Uso
├── WiseCart.CrossCutting/  	# Serviços e configurações
├── WiseCart.Domain/       	# Entidades e Regras
├── WiseCart.Infra/        	# Implementações
└── WiseCart.Front/        	# Protótipo Web
WiseCartReact/wisecart-app      # Aplicativo Mobile
```
