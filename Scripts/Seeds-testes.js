/**
 * Building seeds for test the view
 */

$(function () {
    /**
     * Rotina de pessoas
     */
    const numberRandom = Math.floor(Math.random() * (15 - 10)) + 10; // returns a random integer from 15 for max and 10 for min
    const numberRgRandom = Math.floor(Math.random() * 1000000000) + 1; // returns a random integer from 1 to 100 for rg
    const trueOrFalse = Math.round(Math.random() * 1); // returns a random 1 or 0 for boolean
    $("#tipo_pessoa").val("5");
    $("#nome").val(buildNameSeed(5) + numberRandom);
    $("#email").val(buildNameSeed(5)+".teste." + numberRandom + "@gmail.com");
    $("#f_j").val("j");
    $("#rg_cnpj").val(numberRgRandom);
    $("#cpf").val("15507027005");
    $("#logradouro").val("paraguai");
    $("#numero").val("180");
    $("#cep").val("09617040");
    $("#bairro").val("rudge ramos");
    $("#municipio").val("sao bernardo");
    $("#uf").val("sp");
    $("#regiao").val("sudeste");
    $("#telefone").val("1122224455");
    $("#celular").val("11952354537");
    $("#tipo_carteira").val("A");
    $("#cnh").val("1234567891");
    $("#pontos").val("5");
    $("#data-contratacao").val("2019-10-31");
    $("#tipo_fornec").val("teste");
    $("#tipo_msa1").val("teste1");
    $("#tipo_msa2").val("teste2");
    $("#tipo_msa3").val("teste3");
    $("#obs").val("motoca");

    /**
     * Rotina de veiculos
     */

    let proprio_alugado = "Nao";

    if (trueOrFalse == 1) {
        proprio_alugado = "Sim";
    }

    $("#proprio_alugado").val(proprio_alugado);
    $("#placa").val("PSP5140");
    $("#uf").val("AM");
    $("#chassi").val("9bg116bw04c400001");
    $("#tipo_chassi").val("2");
    $("#marca").val("Fiat");
    $("#modelo").val("Siena 2008");
    $("#cor").val("prata");
    $("#km").val("350000");
    $("#combustivel").val("álcool");
    $("#observacao").val("Sem freio");

    /**
    * Rotina de viagens
    */

    $("#codigo_motorista").val(6);
    $("#codigo_cliente").val(3);
    $("#codigo_veiculo").val(2);
    $("#dataSaida").val("09-11-2019");
    $("#prevChegada").val("15-11-2019");
    $("#dataChegada").val("16-11-2019");
    $("#valor_viagem").val("100,90");
    $("#notaFiscal").val("124564564");

    /**
    * Rotina de manutencao
    */

    $("#tipo_manutencao").val("correcao nivel medio");
    $("#motivo_manutencao").val("Os 4 pneus estouraram, e precisa fazer alinhamento");
    $("#data_manutencao").val("2019-11-10");
    $("#valor_manutencao").val("250,00");


    /**
    * Rotina de locacao
    */

    $("#data_locacao").val("2019-11-10");
    $("#data_entrega").val("2019-12-05");
    $("#qtd_dias_locacao").val(25);
    $("#km_original_locacao").val(15000);
    $("#km_nova_locacao").val(20000);
    $("#valor_locacao").val("350,00");
    $("#nf_locacao").val("124564564");


    /**
    * Rotina de ocorrencias
    */

    $("#motivo_ocorrencia").val("Estava dirigindo sem cinto");
    $("#pontos_ocorrencia").val(10);
    $("#qtd_dias_locacao").val(25);
    $("#valor_ocorrencia").val(15000);
    $("#obs_ocorrencia").val("");
});


/**
 * 
 * Generate letters for building name
 */
function buildNameSeed(length) {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < length; i++) {
        result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
}