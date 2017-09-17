var Script = function () {

    $(".sparkline").each(function(){
        var $data = $(this).data();

        $data.valueSpots = {'0:': $data.spotColor};

        $(this).sparkline( $data.data || "html", $data,
        {
            tooltipFormat: '<span style="display:block; padding:0px 10px 12px 0px;">' +
            '<span style="color: {{color}}">&#9679;</span> {{offset:names}} ({{percent.1}}%)</span>'
        });




    });

//sparkline chart
    $("#barchart").sparkline([71,66,57,49,42,38,35,32,28,25], {
        type: 'bar',
        height: '140',
        barWidth: 30,
        barSpacing: 10,
        barColor: '#fff',
        tooltipFormat: '<span style="display:block; padding:0px 10px 12px 0px;">' +
            '<span style="color: {{color}}">&#9679;</span> {{offset:names}} ({{value}})</span>',
        tooltipValueLookups: {
            names: ['MINI BISCOITO DE ARROZ INTEGRAL CAMIL 150G',
                    'ARROZ AP CREMOSO 1 kg',
                    'ARROZ PRETO CAMIL 12X250 g',
                    'FEIJAO JALO T-1 CAMIL -  0,5 kg',
                    'MINI BISCOITO DE ARROZ INTEGRAL CAMIL 150G',
                    'ARROZ AP CREMOSO 1 kg',
                    'ARROZ PRETO CAMIL 12X250 g',
                    'FEIJAO JALO T-1 CAMIL -  0,5 kg',
                    'MINI BISCOITO DE ARROZ INTEGRAL CAMIL 150G',
                    'ARROZ AP CREMOSO 1 kg']
        }
    });

    $("#barchart2").sparkline([71,66,57,49,42,38,35,32,28,25], {
        type: 'bar',
        height: '140',
        barWidth: 30,
        barSpacing: 10,
        barColor: '#fff',
        tooltipFormat: '<span style="display:block; padding:0px 10px 12px 0px;">' +
            '<span style="color: {{color}}">&#9679;</span> {{offset:names}} ({{value}})</span>',
        tooltipValueLookups: {
            names: ['S&atilde;o Paulo',
                    'Minas Gerais',
                    'Pernambuco',
                    'Rio de Janeiro',
                    'Santa Catarina',
                    'Bahia',
                    'Goi&acute;s',
                    'Rio Grande do Sul',
                    'Tocantins',
                    'Esp&iacute;rito Santo']
        }
    });

    $("#pie-chart1").sparkline([230,248], {
        type: 'pie',
        width: '190',
        height: '190',
        sliceColors: ['#57C8F2', '#FF6C60'],
        tooltipFormat: '<span style="display:block; padding:0px 10px 12px 0px;">' +
    '<span style="color: {{color}}">&#9679;</span> {{offset:names}} ({{value}} - {{percent.1}}%)</span>',
        tooltipValueLookups: {
            names: ['Masculino', 'Feminino']
        }
    });

    $("#pie-chart3").sparkline([539,687,128], {
        type: 'pie',
        width: '190',
        height: '190',
        sliceColors: ['#A8D76F', '#F8D347', '#FF6C60'],
        tooltipFormat: '<span style="display:block; padding:0px 10px 12px 0px;">' +
    '<span style="color: {{color}}">&#9679;</span> {{offset:names}} ({{value}} - {{percent.1}}%)</span>',
        tooltipValueLookups: {
            names: ['Troca', 'Prazo de Validade','Danos']
        }
    });

    $("#pie-chart2").sparkline([2, 5, 3, 1], {
        type: 'pie',
        width: '190',
        height: '190',
        sliceColors: ['#41CAC0', '#A8D76F', '#F8D347', '#EF6F66'],
        tooltipFormat: '<span style="display:block; padding:0px 10px 12px 0px;">' +
    '<span style="color: {{color}}">&#9679;</span> {{offset:names}} ({{value}} - {{percent.1}}%)</span>',
        tooltipValueLookups: {
            names: ['20-30 anos', '30-40 anos', '50-60 anos', 'mais de 60 anos']
        }
    });

}();