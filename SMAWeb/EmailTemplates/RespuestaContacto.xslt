﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:decimal-format name="us" decimal-separator='.' grouping-separator=',' />
  <xsl:output method="html" indent="yes" />
  <xsl:template match="@* | node()">
    <html>
      <head>
        <title>Service Market - Servicios Persona a Persona</title>
        <style type="text/css">


          .input-block-level {
          display: block;
          width: 100%;
          min-height: 30px;
          -webkit-box-sizing: border-box;
          -moz-box-sizing: border-box;
          box-sizing: border-box;
          }

          html {
          font-size: 100%;
          -webkit-text-size-adjust: 100%;
          -ms-text-size-adjust: 100%;
          }

          a:focus {
          outline: thin dotted #333;
          outline: 5px auto -webkit-focus-ring-color;
          outline-offset: -2px;
          }

          a:hover,
          a:active {
          outline: 0;
          }

          sub,
          sup {
          position: relative;
          font-size: 75%;
          line-height: 0;
          vertical-align: baseline;
          }

          sup {
          top: -0.5em;
          }

          sub {
          bottom: -0.25em;
          }

          img {
          width: auto\9;
          height: auto;
          max-width: 100%;
          vertical-align: middle;
          border: 0;
          -ms-interpolation-mode: bicubic;
          }

          #map_canvas img,
          .google-maps img {
          max-width: none;
          }

          button,
          input,
          select,
          textarea {
          margin: 0;
          font-size: 100%;
          vertical-align: middle;
          }

          button,
          input {
          *overflow: visible;
          line-height: normal;
          }

          button::-moz-focus-inner,
          input::-moz-focus-inner {
          padding: 0;
          border: 0;
          }

          button,
          html input[type="button"],
          input[type="reset"],
          input[type="submit"] {
          cursor: pointer;
          -webkit-appearance: button;
          }

          label,
          select,
          button,
          input[type="button"],
          input[type="reset"],
          input[type="submit"],
          input[type="radio"],
          input[type="checkbox"] {
          cursor: pointer;
          }

          input[type="search"] {
          -webkit-box-sizing: content-box;
          -moz-box-sizing: content-box;
          box-sizing: content-box;
          -webkit-appearance: textfield;
          }

          input[type="search"]::-webkit-search-decoration,
          input[type="search"]::-webkit-search-cancel-button {
          -webkit-appearance: none;
          }

          textarea {
          overflow: auto;
          vertical-align: top;
          }

          @media print {
          * {
          color: #000 !important;
          text-shadow: none !important;
          background: transparent !important;
          box-shadow: none !important;
          }
          a,
          a:visited {
          text-decoration: underline;
          }
          a[href]:after {
          content: " (" attr(href) ")";
          }
          abbr[title]:after {
          content: " (" attr(title) ")";
          }
          .ir a:after,
          a[href^="javascript:"]:after,
          a[href^="#"]:after {
          content: "";
          }
          pre,
          blockquote {
          border: 1px solid #999;
          page-break-inside: avoid;
          }
          thead {
          display: table-header-group;
          }
          tr,
          img {
          page-break-inside: avoid;
          }
          img {
          max-width: 100% !important;
          }
          @page  {
          margin: 0.5cm;
          }
          p,
          h2,
          h3 {
          orphans: 3;
          widows: 3;
          }
          h2,
          h3 {
          page-break-after: avoid;
          }
          }

          body {
          margin: 0;
          font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
          font-size: 14px;
          line-height: 20px;
          color: #333333;
          background-color: #ffffff;
          }

          a {
          color: #0088cc;
          text-decoration: none;
          }

          a:hover,
          a:focus {
          color: #005580;
          text-decoration: underline;
          }

          .img-rounded {
          -webkit-border-radius: 6px;
          -moz-border-radius: 6px;
          border-radius: 6px;
          }

          .img-polaroid {
          padding: 4px;
          background-color: #fff;
          border: 1px solid #ccc;
          border: 1px solid rgba(0, 0, 0, 0.2);
          -webkit-box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
          -moz-box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
          box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
          }

          .img-circle {
          -webkit-border-radius: 500px;
          -moz-border-radius: 500px;
          border-radius: 500px;
          }

          .row {
          margin-left: -20px;
          *zoom: 1;
          }

          .row:before,
          .row:after {
          display: table;
          line-height: 0;
          content: "";
          }

          .row:after {
          clear: both;
          }

          [class*="span"] {
          float: left;
          min-height: 1px;
          margin-left: 20px;
          }

          .container,
          .navbar-static-top .container,
          .navbar-fixed-top .container,
          .navbar-fixed-bottom .container {
          width: 940px;
          }

          .span12 {
          width: 940px;
          }

          .span11 {
          width: 860px;
          }

          .span10 {
          width: 780px;
          }

          .span9 {
          width: 700px;
          }

          .span8 {
          width: 620px;
          }

          .span7 {
          width: 540px;
          }

          .span6 {
          width: 460px;
          }

          .span5 {
          width: 380px;
          }

          .span4 {
          width: 300px;
          }

          .span3 {
          width: 220px;
          }

          .span2 {
          width: 140px;
          }

          .span1 {
          width: 60px;
          }

          .offset12 {
          margin-left: 980px;
          }

          .offset11 {
          margin-left: 900px;
          }

          .offset10 {
          margin-left: 820px;
          }

          .offset9 {
          margin-left: 740px;
          }

          .offset8 {
          margin-left: 660px;
          }

          .offset7 {
          margin-left: 580px;
          }

          .offset6 {
          margin-left: 500px;
          }

          .offset5 {
          margin-left: 420px;
          }

          .offset4 {
          margin-left: 340px;
          }

          .offset3 {
          margin-left: 260px;
          }

          .offset2 {
          margin-left: 180px;
          }

          .offset1 {
          margin-left: 100px;
          }

          .row-fluid {
          width: 100%;
          *zoom: 1;
          }

          .row-fluid:before,
          .row-fluid:after {
          display: table;
          line-height: 0;
          content: "";
          }

          .row-fluid:after {
          clear: both;
          }

          .row-fluid [class*="span"] {
          display: block;
          float: left;
          width: 100%;
          min-height: 30px;
          margin-left: 2.127659574468085%;
          *margin-left: 2.074468085106383%;
          -webkit-box-sizing: border-box;
          -moz-box-sizing: border-box;
          box-sizing: border-box;
          }

          .row-fluid [class*="span"]:first-child {
          margin-left: 0;
          }

          .row-fluid .controls-row [class*="span"] + [class*="span"] {
          margin-left: 2.127659574468085%;
          }

          .row-fluid .span12 {
          width: 100%;
          *width: 99.94680851063829%;
          }

          .row-fluid .span11 {
          width: 91.48936170212765%;
          *width: 91.43617021276594%;
          }

          .row-fluid .span10 {
          width: 82.97872340425532%;
          *width: 82.92553191489361%;
          }

          .row-fluid .span9 {
          width: 74.46808510638297%;
          *width: 74.41489361702126%;
          }

          .row-fluid .span8 {
          width: 65.95744680851064%;
          *width: 65.90425531914893%;
          }

          .row-fluid .span7 {
          width: 57.44680851063829%;
          *width: 57.39361702127659%;
          }

          .row-fluid .span6 {
          width: 48.93617021276595%;
          *width: 48.88297872340425%;
          }

          .row-fluid .span5 {
          width: 40.42553191489362%;
          *width: 40.37234042553192%;
          }

          .row-fluid .span4 {
          width: 31.914893617021278%;
          *width: 31.861702127659576%;
          }

          .row-fluid .span3 {
          width: 23.404255319148934%;
          *width: 23.351063829787233%;
          }

          .row-fluid .span2 {
          width: 14.893617021276595%;
          *width: 14.840425531914894%;
          }

          .row-fluid .span1 {
          width: 6.382978723404255%;
          *width: 6.329787234042553%;
          }

          .row-fluid .offset12 {
          margin-left: 104.25531914893617%;
          *margin-left: 104.14893617021275%;
          }

          .row-fluid .offset12:first-child {
          margin-left: 102.12765957446808%;
          *margin-left: 102.02127659574467%;
          }

          .row-fluid .offset11 {
          margin-left: 95.74468085106382%;
          *margin-left: 95.6382978723404%;
          }

          .row-fluid .offset11:first-child {
          margin-left: 93.61702127659574%;
          *margin-left: 93.51063829787232%;
          }

          .row-fluid .offset10 {
          margin-left: 87.23404255319149%;
          *margin-left: 87.12765957446807%;
          }

          .row-fluid .offset10:first-child {
          margin-left: 85.1063829787234%;
          *margin-left: 84.99999999999999%;
          }

          .row-fluid .offset9 {
          margin-left: 78.72340425531914%;
          *margin-left: 78.61702127659572%;
          }

          .row-fluid .offset9:first-child {
          margin-left: 76.59574468085106%;
          *margin-left: 76.48936170212764%;
          }

          .row-fluid .offset8 {
          margin-left: 70.2127659574468%;
          *margin-left: 70.10638297872339%;
          }

          .row-fluid .offset8:first-child {
          margin-left: 68.08510638297872%;
          *margin-left: 67.9787234042553%;
          }

          .row-fluid .offset7 {
          margin-left: 61.70212765957446%;
          *margin-left: 61.59574468085106%;
          }

          .row-fluid .offset7:first-child {
          margin-left: 59.574468085106375%;
          *margin-left: 59.46808510638297%;
          }

          .row-fluid .offset6 {
          margin-left: 53.191489361702125%;
          *margin-left: 53.085106382978715%;
          }

          .row-fluid .offset6:first-child {
          margin-left: 51.063829787234035%;
          *margin-left: 50.95744680851063%;
          }

          .row-fluid .offset5 {
          margin-left: 44.68085106382979%;
          *margin-left: 44.57446808510638%;
          }

          .row-fluid .offset5:first-child {
          margin-left: 42.5531914893617%;
          *margin-left: 42.4468085106383%;
          }

          .row-fluid .offset4 {
          margin-left: 36.170212765957444%;
          *margin-left: 36.06382978723405%;
          }

          .row-fluid .offset4:first-child {
          margin-left: 34.04255319148936%;
          *margin-left: 33.93617021276596%;
          }

          .row-fluid .offset3 {
          margin-left: 27.659574468085104%;
          *margin-left: 27.5531914893617%;
          }

          .row-fluid .offset3:first-child {
          margin-left: 25.53191489361702%;
          *margin-left: 25.425531914893618%;
          }

          .row-fluid .offset2 {
          margin-left: 19.148936170212764%;
          *margin-left: 19.04255319148936%;
          }

          .row-fluid .offset2:first-child {
          margin-left: 17.02127659574468%;
          *margin-left: 16.914893617021278%;
          }

          .row-fluid .offset1 {
          margin-left: 10.638297872340425%;
          *margin-left: 10.53191489361702%;
          }

          .row-fluid .offset1:first-child {
          margin-left: 8.51063829787234%;
          *margin-left: 8.404255319148938%;
          }

          [class*="span"].hide,
          .row-fluid [class*="span"].hide {
          display: none;
          }

          [class*="span"].pull-right,
          .row-fluid [class*="span"].pull-right {
          float: right;
          }

          .container {
          margin-right: auto;
          margin-left: auto;
          *zoom: 1;
          }

          .container:before,
          .container:after {
          display: table;
          line-height: 0;
          content: "";
          }

          .container:after {
          clear: both;
          }

          .container-fluid {
          padding-right: 20px;
          padding-left: 20px;
          *zoom: 1;
          }

          .container-fluid:before,
          .container-fluid:after {
          display: table;
          line-height: 0;
          content: "";
          }

          .container-fluid:after {
          clear: both;
          }

          p {
          margin: 0 0 10px;
          }

          .lead {
          margin-bottom: 20px;
          font-size: 21px;
          font-weight: 200;
          line-height: 30px;
          }

          small {
          font-size: 85%;
          }

          strong {
          font-weight: bold;
          }

          em {
          font-style: italic;
          }

          cite {
          font-style: normal;
          }

          .muted {
          color: #999999;
          }

          a.muted:hover,
          a.muted:focus {
          color: #808080;
          }

          .text-warning {
          color: #c09853;
          }

          a.text-warning:hover,
          a.text-warning:focus {
          color: #a47e3c;
          }

          .text-error {
          color: #b94a48;
          }

          a.text-error:hover,
          a.text-error:focus {
          color: #953b39;
          }

          .text-info {
          color: #3a87ad;
          }

          a.text-info:hover,
          a.text-info:focus {
          color: #2d6987;
          }

          .text-success {
          color: #468847;
          }

          a.text-success:hover,
          a.text-success:focus {
          color: #356635;
          }

          .text-left {
          text-align: left;
          }

          .text-right {
          text-align: right;
          }

          .text-center {
          text-align: center;
          }

          h1,
          h2,
          h3,
          h4,
          h5,
          h6 {
          margin: 10px 0;
          font-family: inherit;
          font-weight: bold;
          line-height: 20px;
          color: inherit;
          text-rendering: optimizelegibility;
          }

          h1 small,
          h2 small,
          h3 small,
          h4 small,
          h5 small,
          h6 small {
          font-weight: normal;
          line-height: 1;
          color: #999999;
          }

          h1,
          h2,
          h3 {
          line-height: 40px;
          }

          h1 {
          font-size: 38.5px;
          }

          h2 {
          font-size: 31.5px;
          }

          h3 {
          font-size: 24.5px;
          }

          h4 {
          font-size: 17.5px;
          }

          h5 {
          font-size: 14px;
          }

          h6 {
          font-size: 11.9px;
          }

          h1 small {
          font-size: 24.5px;
          }

          h2 small {
          font-size: 17.5px;
          }

          h3 small {
          font-size: 14px;
          }

          h4 small {
          font-size: 14px;
          }

          .page-header {
          padding-bottom: 9px;
          margin: 20px 0 30px;
          border-bottom: 1px solid #eeeeee;
          }

          ul,
          ol {
          padding: 0;
          margin: 0 0 10px 25px;
          }

          ul ul,
          ul ol,
          ol ol,
          ol ul {
          margin-bottom: 0;
          }

          li {
          line-height: 20px;
          }

          ul.unstyled,
          ol.unstyled {
          margin-left: 0;
          list-style: none;
          }

          ul.inline,
          ol.inline {
          margin-left: 0;
          list-style: none;
          }

          ul.inline > li,
          ol.inline > li {
          display: inline-block;
          *display: inline;
          padding-right: 5px;
          padding-left: 5px;
          *zoom: 1;
          }

          dl {
          margin-bottom: 20px;
          }

          dt,
          dd {
          line-height: 20px;
          }

          dt {
          font-weight: bold;
          }

          dd {
          margin-left: 10px;
          }

          .dl-horizontal {
          *zoom: 1;
          }

          .dl-horizontal:before,
          .dl-horizontal:after {
          display: table;
          line-height: 0;
          content: "";
          }

          .dl-horizontal:after {
          clear: both;
          }

          .dl-horizontal dt {
          float: left;
          width: 160px;
          overflow: hidden;
          clear: left;
          text-align: right;
          text-overflow: ellipsis;
          white-space: nowrap;
          }

          .dl-horizontal dd {
          margin-left: 180px;
          }

          hr {
          margin: 20px 0;
          border: 0;
          border-top: 1px solid #eeeeee;
          border-bottom: 1px solid #ffffff;
          }

          abbr[title],
          abbr[data-original-title] {
          cursor: help;
          border-bottom: 1px dotted #999999;
          }

          abbr.initialism {
          font-size: 90%;
          text-transform: uppercase;
          }

          blockquote {
          padding: 0 0 0 15px;
          margin: 0 0 20px;
          border-left: 5px solid #eeeeee;
          }

          blockquote p {
          margin-bottom: 0;
          font-size: 17.5px;
          font-weight: 300;
          line-height: 1.25;
          }

          blockquote small {
          display: block;
          line-height: 20px;
          color: #999999;
          }

          blockquote small:before {
          content: '\2014 \00A0';
          }

          blockquote.pull-right {
          float: right;
          padding-right: 15px;
          padding-left: 0;
          border-right: 5px solid #eeeeee;
          border-left: 0;
          }

          blockquote.pull-right p,
          blockquote.pull-right small {
          text-align: right;
          }

          blockquote.pull-right small:before {
          content: '';
          }

          blockquote.pull-right small:after {
          content: '\00A0 \2014';
          }

          q:before,
          q:after,
          blockquote:before,
          blockquote:after {
          content: "";
          }

          address {
          display: block;
          margin-bottom: 20px;
          font-style: normal;
          line-height: 20px;
          }

          code,
          pre {
          padding: 0 3px 2px;
          font-family: Monaco, Menlo, Consolas, "Courier New", monospace;
          font-size: 12px;
          color: #333333;
          -webkit-border-radius: 3px;
          -moz-border-radius: 3px;
          border-radius: 3px;
          }

          code {
          padding: 2px 4px;
          color: #d14;
          white-space: nowrap;
          background-color: #f7f7f9;
          border: 1px solid #e1e1e8;
          }

          pre {
          display: block;
          padding: 9.5px;
          margin: 0 0 10px;
          font-size: 13px;
          line-height: 20px;
          word-break: break-all;
          word-wrap: break-word;
          white-space: pre;
          white-space: pre-wrap;
          background-color: #f5f5f5;
          border: 1px solid #ccc;
          border: 1px solid rgba(0, 0, 0, 0.15);
          -webkit-border-radius: 4px;
          -moz-border-radius: 4px;
          border-radius: 4px;
          }

          pre.prettyprint {
          margin-bottom: 20px;
          }

          pre code {
          padding: 0;
          color: inherit;
          white-space: pre;
          white-space: pre-wrap;
          background-color: transparent;
          border: 0;
          }

          .pre-scrollable {
          max-height: 340px;
          overflow-y: scroll;
          }

          form {
          /*margin: 0 0 20px;*/
          }

          fieldset {
          padding: 0;
          margin: 0;
          border: 0;
          }

          legend {
          display: block;
          width: 100%;
          padding: 0;
          margin-bottom: 20px;
          font-size: 21px;
          line-height: 40px;
          color: #333333;
          border: 0;
          border-bottom: 1px solid #e5e5e5;
          }

          legend small {
          font-size: 15px;
          color: #999999;
          }

          label,
          input,
          button,
          select,
          textarea {
          font-size: 14px;
          font-weight: normal;
          line-height: 20px;
          }

          input,
          button,
          select,
          textarea {
          font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
          }

          label {
          display: block;
          margin-bottom: 5px;
          }

          select,
          textarea,
          input[type="text"],
          input[type="password"],
          input[type="datetime"],
          input[type="datetime-local"],
          input[type="date"],
          input[type="month"],
          input[type="time"],
          input[type="week"],
          input[type="number"],
          input[type="email"],
          input[type="url"],
          input[type="search"],
          input[type="tel"],
          input[type="color"],
          .uneditable-input {
          display: inline-block;
          height: 20px;
          padding: 4px 6px;
          margin-bottom: 10px;
          font-size: 14px;
          line-height: 20px;
          color: #555555;
          vertical-align: middle;
          -webkit-border-radius: 4px;
          -moz-border-radius: 4px;
          border-radius: 4px;
          }

          input,
          textarea,
          .uneditable-input {
          width: 206px;
          }

          textarea {
          height: auto;
          }

          textarea,
          input[type="text"],
          input[type="password"],
          input[type="datetime"],
          input[type="datetime-local"],
          input[type="date"],
          input[type="month"],
          input[type="time"],
          input[type="week"],
          input[type="number"],
          input[type="email"],
          input[type="url"],
          input[type="search"],
          input[type="tel"],
          input[type="color"],
          .uneditable-input {
          background-color: #ffffff;
          border: 1px solid #cccccc;
          -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
          -moz-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
          box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
          -webkit-transition: border linear 0.2s, box-shadow linear 0.2s;
          -moz-transition: border linear 0.2s, box-shadow linear 0.2s;
          -o-transition: border linear 0.2s, box-shadow linear 0.2s;
          transition: border linear 0.2s, box-shadow linear 0.2s;
          }

          textarea:focus,
          input[type="text"]:focus,
          input[type="password"]:focus,
          input[type="datetime"]:focus,
          input[type="datetime-local"]:focus,
          input[type="date"]:focus,
          input[type="month"]:focus,
          input[type="time"]:focus,
          input[type="week"]:focus,
          input[type="number"]:focus,
          input[type="email"]:focus,
          input[type="url"]:focus,
          input[type="search"]:focus,
          input[type="tel"]:focus,
          input[type="color"]:focus,
          .uneditable-input:focus {
          border-color: rgba(82, 168, 236, 0.8);
          outline: 0;
          outline: thin dotted \9;
          /* IE6-9 */

          -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 8px rgba(82, 168, 236, 0.6);
          -moz-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 8px rgba(82, 168, 236, 0.6);
          box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 8px rgba(82, 168, 236, 0.6);
          }

          input[type="radio"],
          input[type="checkbox"] {
          margin: 4px 0 0;
          margin-top: 1px \9;
          *margin-top: 0;
          line-height: normal;
          }

          input[type="file"],
          input[type="image"],
          input[type="submit"],
          input[type="reset"],
          input[type="button"],
          input[type="radio"],
          input[type="checkbox"] {
          width: auto;
          }

          select,
          input[type="file"] {
          height: 30px;
          /* In IE7, the height of the select element cannot be changed by height, only font-size */

          *margin-top: 4px;
          /* For IE7, add top margin to align select with labels */

          line-height: 30px;
          }

          select {
          width: 220px;
          background-color: #ffffff;
          border: 1px solid #cccccc;
          }

          select[multiple],
          select[size] {
          height: auto;
          }

          select:focus,
          input[type="file"]:focus,
          input[type="radio"]:focus,
          input[type="checkbox"]:focus {
          outline: thin dotted #333;
          outline: 5px auto -webkit-focus-ring-color;
          outline-offset: -2px;
          }

          .uneditable-input,
          .uneditable-textarea {
          color: #999999;
          cursor: not-allowed;
          background-color: #fcfcfc;
          border-color: #cccccc;
          -webkit-box-shadow: inset 0 1px 2px rgba(0, 0, 0, 0.025);
          -moz-box-shadow: inset 0 1px 2px rgba(0, 0, 0, 0.025);
          box-shadow: inset 0 1px 2px rgba(0, 0, 0, 0.025);
          }

          .uneditable-input {
          overflow: hidden;
          white-space: nowrap;
          }

          .uneditable-textarea {
          width: auto;
          height: auto;
          }

          input:-moz-placeholder,
          textarea:-moz-placeholder {
          color: #999999;
          }

          input:-ms-input-placeholder,
          textarea:-ms-input-placeholder {
          color: #999999;
          }

          input::-webkit-input-placeholder,
          textarea::-webkit-input-placeholder {
          color: #999999;
          }

          .radio,
          .checkbox {
          min-height: 20px;
          padding-left: 20px;
          }

          .radio input[type="radio"],
          .checkbox input[type="checkbox"] {
          float: left;
          margin-left: -20px;
          }

          .controls > .radio:first-child,
          .controls > .checkbox:first-child {
          padding-top: 5px;
          }

          .radio.inline,
          .checkbox.inline {
          display: inline-block;
          padding-top: 5px;
          margin-bottom: 0;
          vertical-align: middle;
          }

          .radio.inline + .radio.inline,
          .checkbox.inline + .checkbox.inline {
          margin-left: 10px;
          }

          .input-mini {
          width: 60px;
          }

          .input-small {
          width: 90px;
          }

          .input-medium {
          width: 150px;
          }

          .input-large {
          width: 210px;
          }

          .input-xlarge {
          width: 270px;
          }

          .input-xxlarge {
          width: 530px;
          }

          input[class*="span"],
          select[class*="span"],
          textarea[class*="span"],
          .uneditable-input[class*="span"],
          .row-fluid input[class*="span"],
          .row-fluid select[class*="span"],
          .row-fluid textarea[class*="span"],
          .row-fluid .uneditable-input[class*="span"] {
          float: none;
          margin-left: 0;
          }

          .input-append input[class*="span"],
          .input-append .uneditable-input[class*="span"],
          .input-prepend input[class*="span"],
          .input-prepend .uneditable-input[class*="span"],
          .row-fluid input[class*="span"],
          .row-fluid select[class*="span"],
          .row-fluid textarea[class*="span"],
          .row-fluid .uneditable-input[class*="span"],
          .row-fluid .input-prepend [class*="span"],
          .row-fluid .input-append [class*="span"] {
          display: inline-block;
          }

          input,
          textarea,
          .uneditable-input {
          margin-left: 0;
          }

          .controls-row [class*="span"] + [class*="span"] {
          margin-left: 20px;
          }

          input.span12,
          textarea.span12,
          .uneditable-input.span12 {
          width: 926px;
          }

          input.span11,
          textarea.span11,
          .uneditable-input.span11 {
          width: 846px;
          }

          input.span10,
          textarea.span10,
          .uneditable-input.span10 {
          width: 766px;
          }

          input.span9,
          textarea.span9,
          .uneditable-input.span9 {
          width: 686px;
          }

          input.span8,
          textarea.span8,
          .uneditable-input.span8 {
          width: 606px;
          }

          input.span7,
          textarea.span7,
          .uneditable-input.span7 {
          width: 526px;
          }

          input.span6,
          textarea.span6,
          .uneditable-input.span6 {
          width: 446px;
          }

          input.span5,
          textarea.span5,
          .uneditable-input.span5 {
          width: 366px;
          }

          input.span4,
          textarea.span4,
          .uneditable-input.span4 {
          width: 286px;
          }

          input.span3,
          textarea.span3,
          .uneditable-input.span3 {
          width: 206px;
          }

          input.span2,
          textarea.span2,
          .uneditable-input.span2 {
          width: 126px;
          }

          input.span1,
          textarea.span1,
          .uneditable-input.span1 {
          width: 46px;
          }

          .controls-row {
          *zoom: 1;
          }

          .controls-row:before,
          .controls-row:after {
          display: table;
          line-height: 0;
          content: "";
          }

          .controls-row:after {
          clear: both;
          }

          .controls-row [class*="span"],
          .row-fluid .controls-row [class*="span"] {
          float: left;
          }

          .controls-row .checkbox[class*="span"],
          .controls-row .radio[class*="span"] {
          padding-top: 5px;
          }

          input[disabled],
          select[disabled],
          textarea[disabled],
          input[readonly],
          select[readonly],
          textarea[readonly] {
          cursor: not-allowed;
          background-color: #eeeeee;
          }

          input[type="radio"][disabled],
          input[type="checkbox"][disabled],
          input[type="radio"][readonly],
          input[type="checkbox"][readonly] {
          background-color: transparent;
          }

          .control-group.warning .control-label,
          .control-group.warning .help-block,
          .control-group.warning .help-inline {
          color: #c09853;
          }

          .control-group.warning .checkbox,
          .control-group.warning .radio,
          .control-group.warning input,
          .control-group.warning select,
          .control-group.warning textarea {
          color: #c09853;
          }

          .control-group.warning input,
          .control-group.warning select,
          .control-group.warning textarea {
          border-color: #c09853;
          -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
          -moz-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
          box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
          }

          .control-group.warning input:focus,
          .control-group.warning select:focus,
          .control-group.warning textarea:focus {
          border-color: #a47e3c;
          -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 6px #dbc59e;
          -moz-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 6px #dbc59e;
          box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 6px #dbc59e;
          }

          .control-group.warning .input-prepend .add-on,
          .control-group.warning .input-append .add-on {
          color: #c09853;
          background-color: #fcf8e3;
          border-color: #c09853;
          }

          .control-group.error .control-label,
          .control-group.error .help-block,
          .control-group.error .help-inline {
          color: #b94a48;
          }

          .control-group.error .checkbox,
          .control-group.error .radio,
          .control-group.error input,
          .control-group.error select,
          .control-group.error textarea {
          color: #b94a48;
          }

          .control-group.error input,
          .control-group.error select,
          .control-group.error textarea {
          border-color: #b94a48;
          -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
          -moz-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
          box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
          }

          .control-group.error input:focus,
          .control-group.error select:focus,
          .control-group.error textarea:focus {
          border-color: #953b39;
          -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 6px #d59392;
          -moz-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 6px #d59392;
          box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 6px #d59392;
          }

          .control-group.error .input-prepend .add-on,
          .control-group.error .input-append .add-on {
          color: #b94a48;
          background-color: #f2dede;
          border-color: #b94a48;
          }

          .control-group.success .control-label,
          .control-group.success .help-block,
          .control-group.success .help-inline {
          color: #468847;
          }

          .control-group.success .checkbox,
          .control-group.success .radio,
          .control-group.success input,
          .control-group.success select,
          .control-group.success textarea {
          color: #468847;
          }

          .control-group.success input,
          .control-group.success select,
          .control-group.success textarea {
          border-color: #468847;
          -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
          -moz-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
          box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
          }

          .control-group.success input:focus,
          .control-group.success select:focus,
          .control-group.success textarea:focus {
          border-color: #356635;
          -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 6px #7aba7b;
          -moz-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 6px #7aba7b;
          box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 6px #7aba7b;
          }

          .control-group.success .input-prepend .add-on,
          .control-group.success .input-append .add-on {
          color: #468847;
          background-color: #dff0d8;
          border-color: #468847;
          }

          .control-group.info .control-label,
          .control-group.info .help-block,
          .control-group.info .help-inline {
          color: #3a87ad;
          }

          .control-group.info .checkbox,
          .control-group.info .radio,
          .control-group.info input,
          .control-group.info select,
          .control-group.info textarea {
          color: #3a87ad;
          }

          .control-group.info input,
          .control-group.info select,
          .control-group.info textarea {
          border-color: #3a87ad;
          -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
          -moz-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
          box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
          }

          .control-group.info input:focus,
          .control-group.info select:focus,
          .control-group.info textarea:focus {
          border-color: #2d6987;
          -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 6px #7ab5d3;
          -moz-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 6px #7ab5d3;
          box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 6px #7ab5d3;
          }

          .control-group.info .input-prepend .add-on,
          .control-group.info .input-append .add-on {
          color: #3a87ad;
          background-color: #d9edf7;
          border-color: #3a87ad;
          }

          input:focus:invalid,
          textarea:focus:invalid,
          select:focus:invalid {
          color: #b94a48;
          border-color: #ee5f5b;
          }

          input:focus:invalid:focus,
          textarea:focus:invalid:focus,
          select:focus:invalid:focus {
          border-color: #e9322d;
          -webkit-box-shadow: 0 0 6px #f8b9b7;
          -moz-box-shadow: 0 0 6px #f8b9b7;
          box-shadow: 0 0 6px #f8b9b7;
          }

          .form-actions {
          padding: 19px 20px 20px;
          margin-top: 20px;
          margin-bottom: 20px;
          background-color: #f5f5f5;
          border-top: 1px solid #e5e5e5;
          *zoom: 1;
          }

          .form-actions:before,
          .form-actions:after {
          display: table;
          line-height: 0;
          content: "";
          }

          .form-actions:after {
          clear: both;
          }

          .help-block,
          .help-inline {
          color: #595959;
          }

          .help-block {
          display: block;
          margin-bottom: 10px;
          }

          .help-inline {
          display: inline-block;
          *display: inline;
          padding-left: 5px;
          vertical-align: middle;
          *zoom: 1;
          }

          .input-append,
          .input-prepend {
          display: inline-block;
          margin-bottom: 10px;
          font-size: 0;
          white-space: nowrap;
          vertical-align: middle;
          }

          .input-append input,
          .input-prepend input,
          .input-append select,
          .input-prepend select,
          .input-append .uneditable-input,
          .input-prepend .uneditable-input,
          .input-append .dropdown-menu,
          .input-prepend .dropdown-menu,
          .input-append .popover,
          .input-prepend .popover {
          font-size: 14px;
          }

          .input-append input,
          .input-prepend input,
          .input-append select,
          .input-prepend select,
          .input-append .uneditable-input,
          .input-prepend .uneditable-input {
          position: relative;
          margin-bottom: 0;
          *margin-left: 0;
          vertical-align: top;
          -webkit-border-radius: 0 4px 4px 0;
          -moz-border-radius: 0 4px 4px 0;
          border-radius: 0 4px 4px 0;
          }

          .input-append input:focus,
          .input-prepend input:focus,
          .input-append select:focus,
          .input-prepend select:focus,
          .input-append .uneditable-input:focus,
          .input-prepend .uneditable-input:focus {
          z-index: 2;
          }

          .input-append .add-on,
          .input-prepend .add-on {
          display: inline-block;
          width: auto;
          height: 20px;
          min-width: 16px;
          padding: 4px 5px;
          font-size: 14px;
          font-weight: normal;
          line-height: 20px;
          text-align: center;
          text-shadow: 0 1px 0 #ffffff;
          background-color: #eeeeee;
          border: 1px solid #ccc;
          }

          .input-append .add-on,
          .input-prepend .add-on,
          .input-append .btn,
          .input-prepend .btn,
          .input-append .btn-group > .dropdown-toggle,
          .input-prepend .btn-group > .dropdown-toggle {
          vertical-align: top;
          -webkit-border-radius: 0;
          -moz-border-radius: 0;
          border-radius: 0;
          }

          .input-append .active,
          .input-prepend .active {
          background-color: #a9dba9;
          border-color: #46a546;
          }

          .input-prepend .add-on,
          .input-prepend .btn {
          margin-right: -1px;
          }

          .input-prepend .add-on:first-child,
          .input-prepend .btn:first-child {
          -webkit-border-radius: 4px 0 0 4px;
          -moz-border-radius: 4px 0 0 4px;
          border-radius: 4px 0 0 4px;
          }

          .input-append input,
          .input-append select,
          .input-append .uneditable-input {
          -webkit-border-radius: 4px 0 0 4px;
          -moz-border-radius: 4px 0 0 4px;
          border-radius: 4px 0 0 4px;
          }

          .input-append input + .btn-group .btn:last-child,
          .input-append select + .btn-group .btn:last-child,
          .input-append .uneditable-input + .btn-group .btn:last-child {
          -webkit-border-radius: 0 4px 4px 0;
          -moz-border-radius: 0 4px 4px 0;
          border-radius: 0 4px 4px 0;
          }

          .input-append .add-on,
          .input-append .btn,
          .input-append .btn-group {
          margin-left: -1px;
          }

          .input-append .add-on:last-child,
          .input-append .btn:last-child,
          .input-append .btn-group:last-child > .dropdown-toggle {
          -webkit-border-radius: 0 4px 4px 0;
          -moz-border-radius: 0 4px 4px 0;
          border-radius: 0 4px 4px 0;
          }

          .input-prepend.input-append input,
          .input-prepend.input-append select,
          .input-prepend.input-append .uneditable-input {
          -webkit-border-radius: 0;
          -moz-border-radius: 0;
          border-radius: 0;
          }

          .input-prepend.input-append input + .btn-group .btn,
          .input-prepend.input-append select + .btn-group .btn,
          .input-prepend.input-append .uneditable-input + .btn-group .btn {
          -webkit-border-radius: 0 4px 4px 0;
          -moz-border-radius: 0 4px 4px 0;
          border-radius: 0 4px 4px 0;
          }

          .input-prepend.input-append .add-on:first-child,
          .input-prepend.input-append .btn:first-child {
          margin-right: -1px;
          -webkit-border-radius: 4px 0 0 4px;
          -moz-border-radius: 4px 0 0 4px;
          border-radius: 4px 0 0 4px;
          }

          .input-prepend.input-append .add-on:last-child,
          .input-prepend.input-append .btn:last-child {
          margin-left: -1px;
          -webkit-border-radius: 0 4px 4px 0;
          -moz-border-radius: 0 4px 4px 0;
          border-radius: 0 4px 4px 0;
          }

          .input-prepend.input-append .btn-group:first-child {
          margin-left: 0;
          }

          input.search-query {
          padding-right: 14px;
          padding-right: 4px \9;
          padding-left: 14px;
          padding-left: 4px \9;
          /* IE7-8 doesn't have border-radius, so don't indent the padding */

          margin-bottom: 0;
          -webkit-border-radius: 15px;
          -moz-border-radius: 15px;
          border-radius: 15px;
          }

          /* Allow for input prepend/append in search forms */

          .form-search .input-append .search-query,
          .form-search .input-prepend .search-query {
          -webkit-border-radius: 0;
          -moz-border-radius: 0;
          border-radius: 0;
          }

          .form-search .input-append .search-query {
          -webkit-border-radius: 14px 0 0 14px;
          -moz-border-radius: 14px 0 0 14px;
          border-radius: 14px 0 0 14px;
          }

          .form-search .input-append .btn {
          -webkit-border-radius: 0 14px 14px 0;
          -moz-border-radius: 0 14px 14px 0;
          border-radius: 0 14px 14px 0;
          }

          .form-search .input-prepend .search-query {
          -webkit-border-radius: 0 14px 14px 0;
          -moz-border-radius: 0 14px 14px 0;
          border-radius: 0 14px 14px 0;
          }

          .form-search .input-prepend .btn {
          -webkit-border-radius: 14px 0 0 14px;
          -moz-border-radius: 14px 0 0 14px;
          border-radius: 14px 0 0 14px;
          }

          .form-search input,
          .form-inline input,
          .form-horizontal input,
          .form-search textarea,
          .form-inline textarea,
          .form-horizontal textarea,
          .form-search select,
          .form-inline select,
          .form-horizontal select,
          .form-search .help-inline,
          .form-inline .help-inline,
          .form-horizontal .help-inline,
          .form-search .uneditable-input,
          .form-inline .uneditable-input,
          .form-horizontal .uneditable-input,
          .form-search .input-prepend,
          .form-inline .input-prepend,
          .form-horizontal .input-prepend,
          .form-search .input-append,
          .form-inline .input-append,
          .form-horizontal .input-append {
          display: inline-block;
          *display: inline;
          margin-bottom: 0;
          vertical-align: middle;
          *zoom: 1;
          }

          .form-search .hide,
          .form-inline .hide,
          .form-horizontal .hide {
          display: none;
          }

          .form-search label,
          .form-inline label,
          .form-search .btn-group,
          .form-inline .btn-group {
          display: inline-block;
          }

          .form-search .input-append,
          .form-inline .input-append,
          .form-search .input-prepend,
          .form-inline .input-prepend {
          margin-bottom: 0;
          }

          .form-search .radio,
          .form-search .checkbox,
          .form-inline .radio,
          .form-inline .checkbox {
          padding-left: 0;
          margin-bottom: 0;
          vertical-align: middle;
          }

          .form-search .radio input[type="radio"],
          .form-search .checkbox input[type="checkbox"],
          .form-inline .radio input[type="radio"],
          .form-inline .checkbox input[type="checkbox"] {
          float: left;
          margin-right: 3px;
          margin-left: 0;
          }

          .control-group {
          margin-bottom: 10px;
          }

          legend + .control-group {
          margin-top: 20px;
          -webkit-margin-top-collapse: separate;
          }

          .form-horizontal .control-group {
          margin-bottom: 20px;
          *zoom: 1;
          }

          .form-horizontal .control-group:before,
          .form-horizontal .control-group:after {
          display: table;
          line-height: 0;
          content: "";
          }

          .form-horizontal .control-group:after {
          clear: both;
          }

          .form-horizontal .control-label {
          float: left;
          width: 160px;
          padding-top: 5px;
          text-align: right;
          }

          .form-horizontal .controls {
          *display: inline-block;
          *padding-left: 20px;
          margin-left: 180px;
          *margin-left: 0;
          }

          .form-horizontal .controls:first-child {
          *padding-left: 180px;
          }

          .form-horizontal .help-block {
          margin-bottom: 0;
          }

          .form-horizontal input + .help-block,
          .form-horizontal select + .help-block,
          .form-horizontal textarea + .help-block,
          .form-horizontal .uneditable-input + .help-block,
          .form-horizontal .input-prepend + .help-block,
          .form-horizontal .input-append + .help-block {
          margin-top: 10px;
          }

          .form-horizontal .form-actions {
          padding-left: 180px;
          }

          table {
          max-width: 100%;
          background-color: transparent;
          border-collapse: collapse;
          border-spacing: 0;
          }

          .table {
          width: 100%;
          margin-bottom: 20px;
          }

          .table th,
          .table td {
          padding: 8px;
          line-height: 20px;
          text-align: left;
          vertical-align: top;
          border-top: 1px solid #dddddd;
          }

          .table th {
          font-weight: bold;
          }

          .table thead th {
          vertical-align: bottom;
          }

          .table caption + thead tr:first-child th,
          .table caption + thead tr:first-child td,
          .table colgroup + thead tr:first-child th,
          .table colgroup + thead tr:first-child td,
          .table thead:first-child tr:first-child th,
          .table thead:first-child tr:first-child td {
          border-top: 0;
          }

          .table tbody + tbody {
          border-top: 2px solid #dddddd;
          }

          .table .table {
          background-color: #ffffff;
          }

          .table-condensed th,
          .table-condensed td {
          padding: 4px 5px;
          }

          .table-bordered {
          border: 1px solid #dddddd;
          border-collapse: separate;
          *border-collapse: collapse;
          border-left: 0;
          -webkit-border-radius: 4px;
          -moz-border-radius: 4px;
          border-radius: 4px;
          }

          .table-bordered th,
          .table-bordered td {
          border-left: 1px solid #dddddd;
          }

          .table-bordered caption + thead tr:first-child th,
          .table-bordered caption + tbody tr:first-child th,
          .table-bordered caption + tbody tr:first-child td,
          .table-bordered colgroup + thead tr:first-child th,
          .table-bordered colgroup + tbody tr:first-child th,
          .table-bordered colgroup + tbody tr:first-child td,
          .table-bordered thead:first-child tr:first-child th,
          .table-bordered tbody:first-child tr:first-child th,
          .table-bordered tbody:first-child tr:first-child td {
          border-top: 0;
          }

          .table-bordered thead:first-child tr:first-child > th:first-child,
          .table-bordered tbody:first-child tr:first-child > td:first-child,
          .table-bordered tbody:first-child tr:first-child > th:first-child {
          -webkit-border-top-left-radius: 4px;
          border-top-left-radius: 4px;
          -moz-border-radius-topleft: 4px;
          }

          .table-bordered thead:first-child tr:first-child > th:last-child,
          .table-bordered tbody:first-child tr:first-child > td:last-child,
          .table-bordered tbody:first-child tr:first-child > th:last-child {
          -webkit-border-top-right-radius: 4px;
          border-top-right-radius: 4px;
          -moz-border-radius-topright: 4px;
          }

          .table-bordered thead:last-child tr:last-child > th:first-child,
          .table-bordered tbody:last-child tr:last-child > td:first-child,
          .table-bordered tbody:last-child tr:last-child > th:first-child,
          .table-bordered tfoot:last-child tr:last-child > td:first-child,
          .table-bordered tfoot:last-child tr:last-child > th:first-child {
          -webkit-border-bottom-left-radius: 4px;
          border-bottom-left-radius: 4px;
          -moz-border-radius-bottomleft: 4px;
          }

          .table-bordered thead:last-child tr:last-child > th:last-child,
          .table-bordered tbody:last-child tr:last-child > td:last-child,
          .table-bordered tbody:last-child tr:last-child > th:last-child,
          .table-bordered tfoot:last-child tr:last-child > td:last-child,
          .table-bordered tfoot:last-child tr:last-child > th:last-child {
          -webkit-border-bottom-right-radius: 4px;
          border-bottom-right-radius: 4px;
          -moz-border-radius-bottomright: 4px;
          }

          .table-bordered tfoot + tbody:last-child tr:last-child td:first-child {
          -webkit-border-bottom-left-radius: 0;
          border-bottom-left-radius: 0;
          -moz-border-radius-bottomleft: 0;
          }

          .table-bordered tfoot + tbody:last-child tr:last-child td:last-child {
          -webkit-border-bottom-right-radius: 0;
          border-bottom-right-radius: 0;
          -moz-border-radius-bottomright: 0;
          }

          .table-bordered caption + thead tr:first-child th:first-child,
          .table-bordered caption + tbody tr:first-child td:first-child,
          .table-bordered colgroup + thead tr:first-child th:first-child,
          .table-bordered colgroup + tbody tr:first-child td:first-child {
          -webkit-border-top-left-radius: 4px;
          border-top-left-radius: 4px;
          -moz-border-radius-topleft: 4px;
          }

          .table-bordered caption + thead tr:first-child th:last-child,
          .table-bordered caption + tbody tr:first-child td:last-child,
          .table-bordered colgroup + thead tr:first-child th:last-child,
          .table-bordered colgroup + tbody tr:first-child td:last-child {
          -webkit-border-top-right-radius: 4px;
          border-top-right-radius: 4px;
          -moz-border-radius-topright: 4px;
          }

          .table-striped tbody > tr:nth-child(odd) > td,
          .table-striped tbody > tr:nth-child(odd) > th {
          background-color: #f9f9f9;
          }

          .table-hover tbody tr:hover > td,
          .table-hover tbody tr:hover > th {
          background-color: #f5f5f5;
          }

          table td[class*="span"],
          table th[class*="span"],
          .row-fluid table td[class*="span"],
          .row-fluid table th[class*="span"] {
          display: table-cell;
          float: none;
          margin-left: 0;
          }

          .table td.span1,
          .table th.span1 {
          float: none;
          width: 44px;
          margin-left: 0;
          }

          .table td.span2,
          .table th.span2 {
          float: none;
          width: 124px;
          margin-left: 0;
          }

          .table td.span3,
          .table th.span3 {
          float: none;
          width: 204px;
          margin-left: 0;
          }

          .table td.span4,
          .table th.span4 {
          float: none;
          width: 284px;
          margin-left: 0;
          }

          .table td.span5,
          .table th.span5 {
          float: none;
          width: 364px;
          margin-left: 0;
          }

          .table td.span6,
          .table th.span6 {
          float: none;
          width: 444px;
          margin-left: 0;
          }

          .table td.span7,
          .table th.span7 {
          float: none;
          width: 524px;
          margin-left: 0;
          }

          .table td.span8,
          .table th.span8 {
          float: none;
          width: 604px;
          margin-left: 0;
          }

          .table td.span9,
          .table th.span9 {
          float: none;
          width: 684px;
          margin-left: 0;
          }

          .table td.span10,
          .table th.span10 {
          float: none;
          width: 764px;
          margin-left: 0;
          }

          .table td.span11,
          .table th.span11 {
          float: none;
          width: 844px;
          margin-left: 0;
          }

          .table td.span12,
          .table th.span12 {
          float: none;
          width: 924px;
          margin-left: 0;
          }

          .table tbody tr.success > td {
          background-color: #dff0d8;
          }

          .table tbody tr.error > td {
          background-color: #f2dede;
          }

          .table tbody tr.warning > td {
          background-color: #fcf8e3;
          }

          .table tbody tr.info > td {
          background-color: #d9edf7;
          }

          .table-hover tbody tr.success:hover > td {
          background-color: #d0e9c6;
          }

          .table-hover tbody tr.error:hover > td {
          background-color: #ebcccc;
          }

          .table-hover tbody tr.warning:hover > td {
          background-color: #faf2cc;
          }

          .table-hover tbody tr.info:hover > td {
          background-color: #c4e3f3;
          }

          [class^="icon-"],
          [class*=" icon-"] {
          display: inline-block;
          width: 14px;
          height: 14px;
          margin-top: 1px;
          *margin-right: .3em;
          line-height: 14px;
          vertical-align: text-top;
          background-image: url("../img/glyphicons-halflings.png");
          background-position: 14px 14px;
          background-repeat: no-repeat;
          }

          /* White icons with optional class, or on hover/focus/active states of certain elements */

          .icon-white,
          .nav-pills > .active > a > [class^="icon-"],
          .nav-pills > .active > a > [class*=" icon-"],
          .nav-list > .active > a > [class^="icon-"],
          .nav-list > .active > a > [class*=" icon-"],
          .navbar-inverse .nav > .active > a > [class^="icon-"],
          .navbar-inverse .nav > .active > a > [class*=" icon-"],
          .dropdown-menu > li > a:hover > [class^="icon-"],
          .dropdown-menu > li > a:focus > [class^="icon-"],
          .dropdown-menu > li > a:hover > [class*=" icon-"],
          .dropdown-menu > li > a:focus > [class*=" icon-"],
          .dropdown-menu > .active > a > [class^="icon-"],
          .dropdown-menu > .active > a > [class*=" icon-"],
          .dropdown-submenu:hover > a > [class^="icon-"],
          .dropdown-submenu:focus > a > [class^="icon-"],
          .dropdown-submenu:hover > a > [class*=" icon-"],
          .dropdown-submenu:focus > a > [class*=" icon-"] {
          background-image: url("../img/glyphicons-halflings-white.png");
          }

          .icon-glass {
          background-position: 0      0;
          }

          .icon-music {
          background-position: -24px 0;
          }

          .icon-search {
          background-position: -48px 0;
          }

          .icon-envelope {
          background-position: -72px 0;
          }

          .icon-heart {
          background-position: -96px 0;
          }

          .icon-star {
          background-position: -120px 0;
          }

          .icon-star-empty {
          background-position: -144px 0;
          }

          .icon-user {
          background-position: -168px 0;
          }

          .icon-film {
          background-position: -192px 0;
          }

          .icon-th-large {
          background-position: -216px 0;
          }

          .icon-th {
          background-position: -240px 0;
          }

          .icon-th-list {
          background-position: -264px 0;
          }

          .icon-ok {
          background-position: -288px 0;
          }

          .icon-remove {
          background-position: -312px 0;
          }

          .icon-zoom-in {
          background-position: -336px 0;
          }

          .icon-zoom-out {
          background-position: -360px 0;
          }

          .icon-off {
          background-position: -384px 0;
          }

          .icon-signal {
          background-position: -408px 0;
          }

          .icon-cog {
          background-position: -432px 0;
          }

          .icon-trash {
          background-position: -456px 0;
          }

          .icon-home {
          background-position: 0 -24px;
          }

          .icon-file {
          background-position: -24px -24px;
          }

          .icon-time {
          background-position: -48px -24px;
          }

          .icon-road {
          background-position: -72px -24px;
          }

          .icon-download-alt {
          background-position: -96px -24px;
          }

          .icon-download {
          background-position: -120px -24px;
          }

          .icon-upload {
          background-position: -144px -24px;
          }

          .icon-inbox {
          background-position: -168px -24px;
          }

          .icon-play-circle {
          background-position: -192px -24px;
          }

          .icon-repeat {
          background-position: -216px -24px;
          }

          .icon-refresh {
          background-position: -240px -24px;
          }

          .icon-list-alt {
          background-position: -264px -24px;
          }

          .icon-lock {
          background-position: -287px -24px;
          }

          .icon-flag {
          background-position: -312px -24px;
          }

          .icon-headphones {
          background-position: -336px -24px;
          }

          .icon-volume-off {
          background-position: -360px -24px;
          }

          .icon-volume-down {
          background-position: -384px -24px;
          }

          .icon-volume-up {
          background-position: -408px -24px;
          }

          .icon-qrcode {
          background-position: -432px -24px;
          }

          .icon-barcode {
          background-position: -456px -24px;
          }

          .icon-tag {
          background-position: 0 -48px;
          }

          .icon-tags {
          background-position: -25px -48px;
          }

          .icon-book {
          background-position: -48px -48px;
          }

          .icon-bookmark {
          background-position: -72px -48px;
          }

          .icon-print {
          background-position: -96px -48px;
          }

          .icon-camera {
          background-position: -120px -48px;
          }

          .icon-font {
          background-position: -144px -48px;
          }

          .icon-bold {
          background-position: -167px -48px;
          }

          .icon-italic {
          background-position: -192px -48px;
          }

          .icon-text-height {
          background-position: -216px -48px;
          }

          .icon-text-width {
          background-position: -240px -48px;
          }

          .icon-align-left {
          background-position: -264px -48px;
          }

          .icon-align-center {
          background-position: -288px -48px;
          }

          .icon-align-right {
          background-position: -312px -48px;
          }

          .icon-align-justify {
          background-position: -336px -48px;
          }

          .icon-list {
          background-position: -360px -48px;
          }

          .icon-indent-left {
          background-position: -384px -48px;
          }

          .icon-indent-right {
          background-position: -408px -48px;
          }

          .icon-facetime-video {
          background-position: -432px -48px;
          }

          .icon-picture {
          background-position: -456px -48px;
          }

          .icon-pencil {
          background-position: 0 -72px;
          }

          .icon-map-marker {
          background-position: -24px -72px;
          }

          .icon-adjust {
          background-position: -48px -72px;
          }

          .icon-tint {
          background-position: -72px -72px;
          }

          .icon-edit {
          background-position: -96px -72px;
          }

          .icon-share {
          background-position: -120px -72px;
          }

          .icon-check {
          background-position: -144px -72px;
          }

          .icon-move {
          background-position: -168px -72px;
          }

          .icon-step-backward {
          background-position: -192px -72px;
          }

          .icon-fast-backward {
          background-position: -216px -72px;
          }

          .icon-backward {
          background-position: -240px -72px;
          }

          .icon-play {
          background-position: -264px -72px;
          }

          .icon-pause {
          background-position: -288px -72px;
          }

          .icon-stop {
          background-position: -312px -72px;
          }

          .icon-forward {
          background-position: -336px -72px;
          }

          .icon-fast-forward {
          background-position: -360px -72px;
          }

          .icon-step-forward {
          background-position: -384px -72px;
          }

          .icon-eject {
          background-position: -408px -72px;
          }

          .icon-chevron-left {
          background-position: -432px -72px;
          }

          .icon-chevron-right {
          background-position: -456px -72px;
          }

          .icon-plus-sign {
          background-position: 0 -96px;
          }

          .icon-minus-sign {
          background-position: -24px -96px;
          }

          .icon-remove-sign {
          background-position: -48px -96px;
          }

          .icon-ok-sign {
          background-position: -72px -96px;
          }

          .icon-question-sign {
          background-position: -96px -96px;
          }

          .icon-info-sign {
          background-position: -120px -96px;
          }

          .icon-screenshot {
          background-position: -144px -96px;
          }

          .icon-remove-circle {
          background-position: -168px -96px;
          }

          .icon-ok-circle {
          background-position: -192px -96px;
          }

          .icon-ban-circle {
          background-position: -216px -96px;
          }

          .icon-arrow-left {
          background-position: -240px -96px;
          }

          .icon-arrow-right {
          background-position: -264px -96px;
          }

          .icon-arrow-up {
          background-position: -289px -96px;
          }

          .icon-arrow-down {
          background-position: -312px -96px;
          }

          .icon-share-alt {
          background-position: -336px -96px;
          }

          .icon-resize-full {
          background-position: -360px -96px;
          }

          .icon-resize-small {
          background-position: -384px -96px;
          }

          .icon-plus {
          background-position: -408px -96px;
          }

          .icon-minus {
          background-position: -433px -96px;
          }

          .icon-asterisk {
          background-position: -456px -96px;
          }

          .icon-exclamation-sign {
          background-position: 0 -120px;
          }

          .icon-gift {
          background-position: -24px -120px;
          }

          .icon-leaf {
          background-position: -48px -120px;
          }

          .icon-fire {
          background-position: -72px -120px;
          }

          .icon-eye-open {
          background-position: -96px -120px;
          }

          .icon-eye-close {
          background-position: -120px -120px;
          }

          .icon-warning-sign {
          background-position: -144px -120px;
          }

          .icon-plane {
          background-position: -168px -120px;
          }

          .icon-calendar {
          background-position: -192px -120px;
          }

          .icon-random {
          width: 16px;
          background-position: -216px -120px;
          }

          .icon-comment {
          background-position: -240px -120px;
          }

          .icon-magnet {
          background-position: -264px -120px;
          }

          .icon-chevron-up {
          background-position: -288px -120px;
          }

          .icon-chevron-down {
          background-position: -313px -119px;
          }

          .icon-retweet {
          background-position: -336px -120px;
          }

          .icon-shopping-cart {
          background-position: -360px -120px;
          }

          .icon-folder-close {
          width: 16px;
          background-position: -384px -120px;
          }

          .icon-folder-open {
          width: 16px;
          background-position: -408px -120px;
          }

          .icon-resize-vertical {
          background-position: -432px -119px;
          }

          .icon-resize-horizontal {
          background-position: -456px -118px;
          }

          .icon-hdd {
          background-position: 0 -144px;
          }

          .icon-bullhorn {
          background-position: -24px -144px;
          }

          .icon-bell {
          background-position: -48px -144px;
          }

          .icon-certificate {
          background-position: -72px -144px;
          }

          .icon-thumbs-up {
          background-position: -96px -144px;
          }

          .icon-thumbs-down {
          background-position: -120px -144px;
          }

          .icon-hand-right {
          background-position: -144px -144px;
          }

          .icon-hand-left {
          background-position: -168px -144px;
          }

          .icon-hand-up {
          background-position: -192px -144px;
          }

          .icon-hand-down {
          background-position: -216px -144px;
          }

          .icon-circle-arrow-right {
          background-position: -240px -144px;
          }

          .icon-circle-arrow-left {
          background-position: -264px -144px;
          }

          .icon-circle-arrow-up {
          background-position: -288px -144px;
          }

          .icon-circle-arrow-down {
          background-position: -312px -144px;
          }

          .icon-globe {
          background-position: -336px -144px;
          }

          .icon-wrench {
          background-position: -360px -144px;
          }

          .icon-tasks {
          background-position: -384px -144px;
          }

          .icon-filter {
          background-position: -408px -144px;
          }

          .icon-briefcase {
          background-position: -432px -144px;
          }

          .icon-fullscreen {
          background-position: -456px -144px;
          }

          .dropup,
          .dropdown {
          position: relative;
          }

          .dropdown-toggle {
          *margin-bottom: -3px;
          }

          .dropdown-toggle:active,
          .open .dropdown-toggle {
          outline: 0;
          }

          .caret {
          display: inline-block;
          width: 0;
          height: 0;
          vertical-align: top;
          border-top: 4px solid #000000;
          border-right: 4px solid transparent;
          border-left: 4px solid transparent;
          content: "";
          }

          .dropdown .caret {
          margin-top: 8px;
          margin-left: 2px;
          }

          .dropdown-menu {
          position: absolute;
          top: 100%;
          left: 0;
          z-index: 1000;
          display: none;
          float: left;
          min-width: 160px;
          padding: 5px 0;
          margin: 2px 0 0;
          list-style: none;
          background-color: #ffffff;
          border: 1px solid #ccc;
          border: 1px solid rgba(0, 0, 0, 0.2);
          *border-right-width: 2px;
          *border-bottom-width: 2px;
          -webkit-border-radius: 6px;
          -moz-border-radius: 6px;
          border-radius: 6px;
          -webkit-box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
          -moz-box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
          box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
          -webkit-background-clip: padding-box;
          -moz-background-clip: padding;
          background-clip: padding-box;
          }

          .dropdown-menu.pull-right {
          right: 0;
          left: auto;
          }

          .dropdown-menu .divider {
          *width: 100%;
          height: 1px;
          margin: 9px 1px;
          *margin: -5px 0 5px;
          overflow: hidden;
          background-color: #e5e5e5;
          border-bottom: 1px solid #ffffff;
          }

          .dropdown-menu > li > a {
          display: block;
          padding: 3px 20px;
          clear: both;
          font-weight: normal;
          line-height: 20px;
          color: #333333;
          white-space: nowrap;
          }

          .dropdown-menu > li > a:hover,
          .dropdown-menu > li > a:focus,
          .dropdown-submenu:hover > a,
          .dropdown-submenu:focus > a {
          color: #ffffff;
          text-decoration: none;
          background-color: #0081c2;
          background-image: -moz-linear-gradient(top, #0088cc, #0077b3);
          background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#0088cc), to(#0077b3));
          background-image: -webkit-linear-gradient(top, #0088cc, #0077b3);
          background-image: -o-linear-gradient(top, #0088cc, #0077b3);
          background-image: linear-gradient(to bottom, #0088cc, #0077b3);
          background-repeat: repeat-x;
          filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ff0088cc', endColorstr='#ff0077b3', GradientType=0);
          }

          .dropdown-menu > .active > a,
          .dropdown-menu > .active > a:hover,
          .dropdown-menu > .active > a:focus {
          color: #ffffff;
          text-decoration: none;
          background-color: #0081c2;
          background-image: -moz-linear-gradient(top, #0088cc, #0077b3);
          background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#0088cc), to(#0077b3));
          background-image: -webkit-linear-gradient(top, #0088cc, #0077b3);
          background-image: -o-linear-gradient(top, #0088cc, #0077b3);
          background-image: linear-gradient(to bottom, #0088cc, #0077b3);
          background-repeat: repeat-x;
          outline: 0;
          filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ff0088cc', endColorstr='#ff0077b3', GradientType=0);
          }

          .dropdown-menu > .disabled > a,
          .dropdown-menu > .disabled > a:hover,
          .dropdown-menu > .disabled > a:focus {
          color: #999999;
          }

          .dropdown-menu > .disabled > a:hover,
          .dropdown-menu > .disabled > a:focus {
          text-decoration: none;
          cursor: default;
          background-color: transparent;
          background-image: none;
          filter: progid:DXImageTransform.Microsoft.gradient(enabled=false);
          }

          .open {
          *z-index: 1000;
          }

          .open > .dropdown-menu {
          display: block;
          }

          .dropdown-backdrop {
          position: fixed;
          top: 0;
          right: 0;
          bottom: 0;
          left: 0;
          z-index: 990;
          }

          .pull-right > .dropdown-menu {
          right: 0;
          left: auto;
          }

          .dropup .caret,
          .navbar-fixed-bottom .dropdown .caret {
          border-top: 0;
          border-bottom: 4px solid #000000;
          content: "";
          }

          .dropup .dropdown-menu,
          .navbar-fixed-bottom .dropdown .dropdown-menu {
          top: auto;
          bottom: 100%;
          margin-bottom: 1px;
          }

          .dropdown-submenu {
          position: relative;
          }

          .dropdown-submenu > .dropdown-menu {
          top: 0;
          left: 100%;
          margin-top: -6px;
          margin-left: -1px;
          -webkit-border-radius: 0 6px 6px 6px;
          -moz-border-radius: 0 6px 6px 6px;
          border-radius: 0 6px 6px 6px;
          }

          .dropdown-submenu:hover > .dropdown-menu {
          display: block;
          }

          .dropup .dropdown-submenu > .dropdown-menu {
          top: auto;
          bottom: 0;
          margin-top: 0;
          margin-bottom: -2px;
          -webkit-border-radius: 5px 5px 5px 0;
          -moz-border-radius: 5px 5px 5px 0;
          border-radius: 5px 5px 5px 0;
          }

          .dropdown-submenu > a:after {
          display: block;
          float: right;
          width: 0;
          height: 0;
          margin-top: 5px;
          margin-right: -10px;
          border-color: transparent;
          border-left-color: #cccccc;
          border-style: solid;
          border-width: 5px 0 5px 5px;
          content: " ";
          }

          .dropdown-submenu:hover > a:after {
          border-left-color: #ffffff;
          }

          .dropdown-submenu.pull-left {
          float: none;
          }

          .dropdown-submenu.pull-left > .dropdown-menu {
          left: -100%;
          margin-left: 10px;
          -webkit-border-radius: 6px 0 6px 6px;
          -moz-border-radius: 6px 0 6px 6px;
          border-radius: 6px 0 6px 6px;
          }

          .dropdown .dropdown-menu .nav-header {
          padding-right: 20px;
          padding-left: 20px;
          }

          .typeahead {
          z-index: 1051;
          margin-top: 2px;
          -webkit-border-radius: 4px;
          -moz-border-radius: 4px;
          border-radius: 4px;
          }

          .well {
          min-height: 20px;
          padding: 19px;
          margin-bottom: 20px;
          background-color: #f5f5f5;
          border: 1px solid #e3e3e3;
          -webkit-border-radius: 4px;
          -moz-border-radius: 4px;
          border-radius: 4px;
          -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.05);
          -moz-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.05);
          box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.05);
          }

          .well blockquote {
          border-color: #ddd;
          border-color: rgba(0, 0, 0, 0.15);
          }

          .well-large {
          padding: 24px;
          -webkit-border-radius: 6px;
          -moz-border-radius: 6px;
          border-radius: 6px;
          }

          .well-small {
          padding: 9px;
          -webkit-border-radius: 3px;
          -moz-border-radius: 3px;
          border-radius: 3px;
          }

          .fade {
          opacity: 0;
          -webkit-transition: opacity 0.15s linear;
          -moz-transition: opacity 0.15s linear;
          -o-transition: opacity 0.15s linear;
          transition: opacity 0.15s linear;
          }

          .fade.in {
          opacity: 1;
          }

          .collapse {
          position: relative;
          height: 0;
          overflow: hidden;
          -webkit-transition: height 0.35s ease;
          -moz-transition: height 0.35s ease;
          -o-transition: height 0.35s ease;
          transition: height 0.35s ease;
          }

          .collapse.in {
          height: auto;
          }

          .close {
          float: right;
          font-size: 20px;
          font-weight: bold;
          line-height: 20px;
          color: #000000;
          text-shadow: 0 1px 0 #ffffff;
          opacity: 0.2;
          filter: alpha(opacity=20);
          }

          .close:hover,
          .close:focus {
          color: #000000;
          text-decoration: none;
          cursor: pointer;
          opacity: 0.4;
          filter: alpha(opacity=40);
          }

          button.close {
          padding: 0;
          cursor: pointer;
          background: transparent;
          border: 0;
          -webkit-appearance: none;
          }

          .btn {
          display: inline-block;
          *display: inline;
          padding: 4px 12px;
          margin-bottom: 0;
          *margin-left: .3em;
          font-size: 14px;
          line-height: 20px;
          color: #333333;
          text-align: center;
          text-shadow: 0 1px 1px rgba(255, 255, 255, 0.75);
          vertical-align: middle;
          cursor: pointer;
          background-color: #f5f5f5;
          *background-color: #e6e6e6;
          background-image: -moz-linear-gradient(top, #ffffff, #e6e6e6);
          background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#ffffff), to(#e6e6e6));
          background-image: -webkit-linear-gradient(top, #ffffff, #e6e6e6);
          background-image: -o-linear-gradient(top, #ffffff, #e6e6e6);
          background-image: linear-gradient(to bottom, #ffffff, #e6e6e6);
          background-repeat: repeat-x;
          border: 1px solid #cccccc;
          *border: 0;
          border-color: #e6e6e6 #e6e6e6 #bfbfbf;
          border-color: rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.25);
          border-bottom-color: #b3b3b3;
          -webkit-border-radius: 4px;
          -moz-border-radius: 4px;
          border-radius: 4px;
          filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ffffffff', endColorstr='#ffe6e6e6', GradientType=0);
          filter: progid:DXImageTransform.Microsoft.gradient(enabled=false);
          *zoom: 1;
          -webkit-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
          -moz-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
          box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
          }

          .btn:hover,
          .btn:focus,
          .btn:active,
          .btn.active,
          .btn.disabled,
          .btn[disabled] {
          color: #333333;
          background-color: #e6e6e6;
          *background-color: #d9d9d9;
          }

          .btn:active,
          .btn.active {
          background-color: #cccccc \9;
          }

          .btn:first-child {
          *margin-left: 0;
          }

          .btn:hover,
          .btn:focus {
          color: #333333;
          text-decoration: none;
          background-position: 0 -15px;
          -webkit-transition: background-position 0.1s linear;
          -moz-transition: background-position 0.1s linear;
          -o-transition: background-position 0.1s linear;
          transition: background-position 0.1s linear;
          }

          .btn:focus {
          outline: thin dotted #333;
          outline: 5px auto -webkit-focus-ring-color;
          outline-offset: -2px;
          }

          .btn.active,
          .btn:active {
          background-image: none;
          outline: 0;
          -webkit-box-shadow: inset 0 2px 4px rgba(0, 0, 0, 0.15), 0 1px 2px rgba(0, 0, 0, 0.05);
          -moz-box-shadow: inset 0 2px 4px rgba(0, 0, 0, 0.15), 0 1px 2px rgba(0, 0, 0, 0.05);
          box-shadow: inset 0 2px 4px rgba(0, 0, 0, 0.15), 0 1px 2px rgba(0, 0, 0, 0.05);
          }

          .btn.disabled,
          .btn[disabled] {
          cursor: default;
          background-image: none;
          opacity: 0.65;
          filter: alpha(opacity=65);
          -webkit-box-shadow: none;
          -moz-box-shadow: none;
          box-shadow: none;
          }

          .btn-large {
          padding: 11px 19px;
          font-size: 17.5px;
          -webkit-border-radius: 6px;
          -moz-border-radius: 6px;
          border-radius: 6px;
          }

          .btn-large [class^="icon-"],
          .btn-large [class*=" icon-"] {
          margin-top: 4px;
          }

          .btn-small {
          padding: 2px 10px;
          font-size: 11.9px;
          -webkit-border-radius: 3px;
          -moz-border-radius: 3px;
          border-radius: 3px;
          }

          .btn-small [class^="icon-"],
          .btn-small [class*=" icon-"] {
          margin-top: 0;
          }

          .btn-mini [class^="icon-"],
          .btn-mini [class*=" icon-"] {
          margin-top: -1px;
          }

          .btn-mini {
          padding: 0 6px;
          font-size: 10.5px;
          -webkit-border-radius: 3px;
          -moz-border-radius: 3px;
          border-radius: 3px;
          }

          .btn-block {
          display: block;
          width: 100%;
          padding-right: 0;
          padding-left: 0;
          -webkit-box-sizing: border-box;
          -moz-box-sizing: border-box;
          box-sizing: border-box;
          }

          .btn-block + .btn-block {
          margin-top: 5px;
          }

          input[type="submit"].btn-block,
          input[type="reset"].btn-block,
          input[type="button"].btn-block {
          width: 100%;
          }

          .btn-primary.active,
          .btn-warning.active,
          .btn-danger.active,
          .btn-success.active,
          .btn-info.active,
          .btn-inverse.active {
          color: rgba(255, 255, 255, 0.75);
          }

          .btn-primary {
          color: #ffffff;
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
          background-color: #006dcc;
          *background-color: #0044cc;
          background-image: -moz-linear-gradient(top, #0088cc, #0044cc);
          background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#0088cc), to(#0044cc));
          background-image: -webkit-linear-gradient(top, #0088cc, #0044cc);
          background-image: -o-linear-gradient(top, #0088cc, #0044cc);
          background-image: linear-gradient(to bottom, #0088cc, #0044cc);
          background-repeat: repeat-x;
          border-color: #0044cc #0044cc #002a80;
          border-color: rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.25);
          filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ff0088cc', endColorstr='#ff0044cc', GradientType=0);
          filter: progid:DXImageTransform.Microsoft.gradient(enabled=false);
          }

          .btn-primary:hover,
          .btn-primary:focus,
          .btn-primary:active,
          .btn-primary.active,
          .btn-primary.disabled,
          .btn-primary[disabled] {
          color: #ffffff;
          background-color: #0044cc;
          *background-color: #003bb3;
          }

          .btn-primary:active,
          .btn-primary.active {
          background-color: #003399 \9;
          }

          .btn-warning {
          color: #ffffff;
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
          background-color: #faa732;
          *background-color: #f89406;
          background-image: -moz-linear-gradient(top, #fbb450, #f89406);
          background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#fbb450), to(#f89406));
          background-image: -webkit-linear-gradient(top, #fbb450, #f89406);
          background-image: -o-linear-gradient(top, #fbb450, #f89406);
          background-image: linear-gradient(to bottom, #fbb450, #f89406);
          background-repeat: repeat-x;
          border-color: #f89406 #f89406 #ad6704;
          border-color: rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.25);
          filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#fffbb450', endColorstr='#fff89406', GradientType=0);
          filter: progid:DXImageTransform.Microsoft.gradient(enabled=false);
          }

          .btn-warning:hover,
          .btn-warning:focus,
          .btn-warning:active,
          .btn-warning.active,
          .btn-warning.disabled,
          .btn-warning[disabled] {
          color: #ffffff;
          background-color: #f89406;
          *background-color: #df8505;
          }

          .btn-warning:active,
          .btn-warning.active {
          background-color: #c67605 \9;
          }

          .btn-danger {
          color: #ffffff;
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
          background-color: #da4f49;
          *background-color: #bd362f;
          background-image: -moz-linear-gradient(top, #ee5f5b, #bd362f);
          background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#ee5f5b), to(#bd362f));
          background-image: -webkit-linear-gradient(top, #ee5f5b, #bd362f);
          background-image: -o-linear-gradient(top, #ee5f5b, #bd362f);
          background-image: linear-gradient(to bottom, #ee5f5b, #bd362f);
          background-repeat: repeat-x;
          border-color: #bd362f #bd362f #802420;
          border-color: rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.25);
          filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ffee5f5b', endColorstr='#ffbd362f', GradientType=0);
          filter: progid:DXImageTransform.Microsoft.gradient(enabled=false);
          }

          .btn-danger:hover,
          .btn-danger:focus,
          .btn-danger:active,
          .btn-danger.active,
          .btn-danger.disabled,
          .btn-danger[disabled] {
          color: #ffffff;
          background-color: #bd362f;
          *background-color: #a9302a;
          }

          .btn-danger:active,
          .btn-danger.active {
          background-color: #942a25 \9;
          }

          .btn-success {
          color: #ffffff;
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
          background-color: #5bb75b;
          *background-color: #51a351;
          background-image: -moz-linear-gradient(top, #62c462, #51a351);
          background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#62c462), to(#51a351));
          background-image: -webkit-linear-gradient(top, #62c462, #51a351);
          background-image: -o-linear-gradient(top, #62c462, #51a351);
          background-image: linear-gradient(to bottom, #62c462, #51a351);
          background-repeat: repeat-x;
          border-color: #51a351 #51a351 #387038;
          border-color: rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.25);
          filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ff62c462', endColorstr='#ff51a351', GradientType=0);
          filter: progid:DXImageTransform.Microsoft.gradient(enabled=false);
          }

          .btn-success:hover,
          .btn-success:focus,
          .btn-success:active,
          .btn-success.active,
          .btn-success.disabled,
          .btn-success[disabled] {
          color: #ffffff;
          background-color: #51a351;
          *background-color: #499249;
          }

          .btn-success:active,
          .btn-success.active {
          background-color: #408140 \9;
          }

          .btn-info {
          color: #ffffff;
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
          background-color: #49afcd;
          *background-color: #2f96b4;
          background-image: -moz-linear-gradient(top, #5bc0de, #2f96b4);
          background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#5bc0de), to(#2f96b4));
          background-image: -webkit-linear-gradient(top, #5bc0de, #2f96b4);
          background-image: -o-linear-gradient(top, #5bc0de, #2f96b4);
          background-image: linear-gradient(to bottom, #5bc0de, #2f96b4);
          background-repeat: repeat-x;
          border-color: #2f96b4 #2f96b4 #1f6377;
          border-color: rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.25);
          filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ff5bc0de', endColorstr='#ff2f96b4', GradientType=0);
          filter: progid:DXImageTransform.Microsoft.gradient(enabled=false);
          }

          .btn-info:hover,
          .btn-info:focus,
          .btn-info:active,
          .btn-info.active,
          .btn-info.disabled,
          .btn-info[disabled] {
          color: #ffffff;
          background-color: #2f96b4;
          *background-color: #2a85a0;
          }

          .btn-info:active,
          .btn-info.active {
          background-color: #24748c \9;
          }

          .btn-inverse {
          color: #ffffff;
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
          background-color: #363636;
          *background-color: #222222;
          background-image: -moz-linear-gradient(top, #444444, #222222);
          background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#444444), to(#222222));
          background-image: -webkit-linear-gradient(top, #444444, #222222);
          background-image: -o-linear-gradient(top, #444444, #222222);
          background-image: linear-gradient(to bottom, #444444, #222222);
          background-repeat: repeat-x;
          border-color: #222222 #222222 #000000;
          border-color: rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.25);
          filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ff444444', endColorstr='#ff222222', GradientType=0);
          filter: progid:DXImageTransform.Microsoft.gradient(enabled=false);
          }

          .btn-inverse:hover,
          .btn-inverse:focus,
          .btn-inverse:active,
          .btn-inverse.active,
          .btn-inverse.disabled,
          .btn-inverse[disabled] {
          color: #ffffff;
          background-color: #222222;
          *background-color: #151515;
          }

          .btn-inverse:active,
          .btn-inverse.active {
          background-color: #080808 \9;
          }

          button.btn,
          input[type="submit"].btn {
          *padding-top: 3px;
          *padding-bottom: 3px;
          }

          button.btn::-moz-focus-inner,
          input[type="submit"].btn::-moz-focus-inner {
          padding: 0;
          border: 0;
          }

          button.btn.btn-large,
          input[type="submit"].btn.btn-large {
          *padding-top: 7px;
          *padding-bottom: 7px;
          }

          button.btn.btn-small,
          input[type="submit"].btn.btn-small {
          *padding-top: 3px;
          *padding-bottom: 3px;
          }

          button.btn.btn-mini,
          input[type="submit"].btn.btn-mini {
          *padding-top: 1px;
          *padding-bottom: 1px;
          }

          .btn-link,
          .btn-link:active,
          .btn-link[disabled] {
          background-color: transparent;
          background-image: none;
          -webkit-box-shadow: none;
          -moz-box-shadow: none;
          box-shadow: none;
          }

          .btn-link {
          color: #0088cc;
          cursor: pointer;
          border-color: transparent;
          -webkit-border-radius: 0;
          -moz-border-radius: 0;
          border-radius: 0;
          }

          .btn-link:hover,
          .btn-link:focus {
          color: #005580;
          text-decoration: underline;
          background-color: transparent;
          }

          .btn-link[disabled]:hover,
          .btn-link[disabled]:focus {
          color: #333333;
          text-decoration: none;
          }

          .btn-group {
          position: relative;
          display: inline-block;
          *display: inline;
          *margin-left: .3em;
          font-size: 0;
          white-space: nowrap;
          vertical-align: middle;
          *zoom: 1;
          }

          .btn-group:first-child {
          *margin-left: 0;
          }

          .btn-group + .btn-group {
          margin-left: 5px;
          }

          .btn-toolbar {
          margin-top: 10px;
          margin-bottom: 10px;
          font-size: 0;
          }

          .btn-toolbar > .btn + .btn,
          .btn-toolbar > .btn-group + .btn,
          .btn-toolbar > .btn + .btn-group {
          margin-left: 5px;
          }

          .btn-group > .btn {
          position: relative;
          -webkit-border-radius: 0;
          -moz-border-radius: 0;
          border-radius: 0;
          }

          .btn-group > .btn + .btn {
          margin-left: -1px;
          }

          .btn-group > .btn,
          .btn-group > .dropdown-menu,
          .btn-group > .popover {
          font-size: 14px;
          }

          .btn-group > .btn-mini {
          font-size: 10.5px;
          }

          .btn-group > .btn-small {
          font-size: 11.9px;
          }

          .btn-group > .btn-large {
          font-size: 17.5px;
          }

          .btn-group > .btn:first-child {
          margin-left: 0;
          -webkit-border-bottom-left-radius: 4px;
          border-bottom-left-radius: 4px;
          -webkit-border-top-left-radius: 4px;
          border-top-left-radius: 4px;
          -moz-border-radius-bottomleft: 4px;
          -moz-border-radius-topleft: 4px;
          }

          .btn-group > .btn:last-child,
          .btn-group > .dropdown-toggle {
          -webkit-border-top-right-radius: 4px;
          border-top-right-radius: 4px;
          -webkit-border-bottom-right-radius: 4px;
          border-bottom-right-radius: 4px;
          -moz-border-radius-topright: 4px;
          -moz-border-radius-bottomright: 4px;
          }

          .btn-group > .btn.large:first-child {
          margin-left: 0;
          -webkit-border-bottom-left-radius: 6px;
          border-bottom-left-radius: 6px;
          -webkit-border-top-left-radius: 6px;
          border-top-left-radius: 6px;
          -moz-border-radius-bottomleft: 6px;
          -moz-border-radius-topleft: 6px;
          }

          .btn-group > .btn.large:last-child,
          .btn-group > .large.dropdown-toggle {
          -webkit-border-top-right-radius: 6px;
          border-top-right-radius: 6px;
          -webkit-border-bottom-right-radius: 6px;
          border-bottom-right-radius: 6px;
          -moz-border-radius-topright: 6px;
          -moz-border-radius-bottomright: 6px;
          }

          .btn-group > .btn:hover,
          .btn-group > .btn:focus,
          .btn-group > .btn:active,
          .btn-group > .btn.active {
          z-index: 2;
          }

          .btn-group .dropdown-toggle:active,
          .btn-group.open .dropdown-toggle {
          outline: 0;
          }

          .btn-group > .btn + .dropdown-toggle {
          *padding-top: 5px;
          padding-right: 8px;
          *padding-bottom: 5px;
          padding-left: 8px;
          -webkit-box-shadow: inset 1px 0 0 rgba(255, 255, 255, 0.125), inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
          -moz-box-shadow: inset 1px 0 0 rgba(255, 255, 255, 0.125), inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
          box-shadow: inset 1px 0 0 rgba(255, 255, 255, 0.125), inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
          }

          .btn-group > .btn-mini + .dropdown-toggle {
          *padding-top: 2px;
          padding-right: 5px;
          *padding-bottom: 2px;
          padding-left: 5px;
          }

          .btn-group > .btn-small + .dropdown-toggle {
          *padding-top: 5px;
          *padding-bottom: 4px;
          }

          .btn-group > .btn-large + .dropdown-toggle {
          *padding-top: 7px;
          padding-right: 12px;
          *padding-bottom: 7px;
          padding-left: 12px;
          }

          .btn-group.open .dropdown-toggle {
          background-image: none;
          -webkit-box-shadow: inset 0 2px 4px rgba(0, 0, 0, 0.15), 0 1px 2px rgba(0, 0, 0, 0.05);
          -moz-box-shadow: inset 0 2px 4px rgba(0, 0, 0, 0.15), 0 1px 2px rgba(0, 0, 0, 0.05);
          box-shadow: inset 0 2px 4px rgba(0, 0, 0, 0.15), 0 1px 2px rgba(0, 0, 0, 0.05);
          }

          .btn-group.open .btn.dropdown-toggle {
          background-color: #e6e6e6;
          }

          .btn-group.open .btn-primary.dropdown-toggle {
          background-color: #0044cc;
          }

          .btn-group.open .btn-warning.dropdown-toggle {
          background-color: #f89406;
          }

          .btn-group.open .btn-danger.dropdown-toggle {
          background-color: #bd362f;
          }

          .btn-group.open .btn-success.dropdown-toggle {
          background-color: #51a351;
          }

          .btn-group.open .btn-info.dropdown-toggle {
          background-color: #2f96b4;
          }

          .btn-group.open .btn-inverse.dropdown-toggle {
          background-color: #222222;
          }

          .btn .caret {
          margin-top: 8px;
          margin-left: 0;
          }

          .btn-large .caret {
          margin-top: 6px;
          }

          .btn-large .caret {
          border-top-width: 5px;
          border-right-width: 5px;
          border-left-width: 5px;
          }

          .btn-mini .caret,
          .btn-small .caret {
          margin-top: 8px;
          }

          .dropup .btn-large .caret {
          border-bottom-width: 5px;
          }

          .btn-primary .caret,
          .btn-warning .caret,
          .btn-danger .caret,
          .btn-info .caret,
          .btn-success .caret,
          .btn-inverse .caret {
          border-top-color: #ffffff;
          border-bottom-color: #ffffff;
          }

          .btn-group-vertical {
          display: inline-block;
          *display: inline;
          /* IE7 inline-block hack */

          *zoom: 1;
          }

          .btn-group-vertical > .btn {
          display: block;
          float: none;
          max-width: 100%;
          -webkit-border-radius: 0;
          -moz-border-radius: 0;
          border-radius: 0;
          }

          .btn-group-vertical > .btn + .btn {
          margin-top: -1px;
          margin-left: 0;
          }

          .btn-group-vertical > .btn:first-child {
          -webkit-border-radius: 4px 4px 0 0;
          -moz-border-radius: 4px 4px 0 0;
          border-radius: 4px 4px 0 0;
          }

          .btn-group-vertical > .btn:last-child {
          -webkit-border-radius: 0 0 4px 4px;
          -moz-border-radius: 0 0 4px 4px;
          border-radius: 0 0 4px 4px;
          }

          .btn-group-vertical > .btn-large:first-child {
          -webkit-border-radius: 6px 6px 0 0;
          -moz-border-radius: 6px 6px 0 0;
          border-radius: 6px 6px 0 0;
          }

          .btn-group-vertical > .btn-large:last-child {
          -webkit-border-radius: 0 0 6px 6px;
          -moz-border-radius: 0 0 6px 6px;
          border-radius: 0 0 6px 6px;
          }

          .alert {
          padding: 8px 35px 8px 14px;
          margin-bottom: 20px;
          text-shadow: 0 1px 0 rgba(255, 255, 255, 0.5);
          background-color: #fcf8e3;
          border: 1px solid #fbeed5;
          -webkit-border-radius: 4px;
          -moz-border-radius: 4px;
          border-radius: 4px;
          }

          .alert,
          .alert h4 {
          color: #c09853;
          }

          .alert h4 {
          margin: 0;
          }

          .alert .close {
          position: relative;
          top: -2px;
          right: -21px;
          line-height: 20px;
          }

          .alert-success {
          color: #468847;
          background-color: #dff0d8;
          border-color: #d6e9c6;
          }

          .alert-success h4 {
          color: #468847;
          }

          .alert-danger,
          .alert-error {
          color: #b94a48;
          background-color: #f2dede;
          border-color: #eed3d7;
          }

          .alert-danger h4,
          .alert-error h4 {
          color: #b94a48;
          }

          .alert-info {
          color: #3a87ad;
          background-color: #d9edf7;
          border-color: #bce8f1;
          }

          .alert-info h4 {
          color: #3a87ad;
          }

          .alert-block {
          padding-top: 14px;
          padding-bottom: 14px;
          }

          .alert-block > p,
          .alert-block > ul {
          margin-bottom: 0;
          }

          .alert-block p + p {
          margin-top: 5px;
          }

          .nav {
          margin-bottom: 20px;
          margin-left: 0;
          list-style: none;
          }

          .nav > li > a {
          display: block;
          }

          .nav > li > a:hover,
          .nav > li > a:focus {
          text-decoration: none;
          background-color: #eeeeee;
          }

          .nav > li > a > img {
          max-width: none;
          }

          .nav > .pull-right {
          float: right;
          }

          .nav-header {
          display: block;
          padding: 3px 15px;
          font-size: 11px;
          font-weight: bold;
          line-height: 20px;
          color: #999999;
          text-shadow: 0 1px 0 rgba(255, 255, 255, 0.5);
          text-transform: uppercase;
          }

          .nav li + .nav-header {
          margin-top: 9px;
          }

          .nav-list {
          padding-right: 15px;
          padding-left: 15px;
          margin-bottom: 0;
          }

          .nav-list > li > a,
          .nav-list .nav-header {
          margin-right: -15px;
          margin-left: -15px;
          text-shadow: 0 1px 0 rgba(255, 255, 255, 0.5);
          }

          .nav-list > li > a {
          padding: 3px 15px;
          }

          .nav-list > .active > a,
          .nav-list > .active > a:hover,
          .nav-list > .active > a:focus {
          color: #ffffff;
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.2);
          background-color: #0088cc;
          }

          .nav-list [class^="icon-"],
          .nav-list [class*=" icon-"] {
          margin-right: 2px;
          }

          .nav-list .divider {
          *width: 100%;
          height: 1px;
          margin: 9px 1px;
          *margin: -5px 0 5px;
          overflow: hidden;
          background-color: #e5e5e5;
          border-bottom: 1px solid #ffffff;
          }

          .nav-tabs,
          .nav-pills {
          *zoom: 1;
          }

          .nav-tabs:before,
          .nav-pills:before,
          .nav-tabs:after,
          .nav-pills:after {
          display: table;
          line-height: 0;
          content: "";
          }

          .nav-tabs:after,
          .nav-pills:after {
          clear: both;
          }

          .nav-tabs > li,
          .nav-pills > li {
          float: left;
          }

          .nav-tabs > li > a,
          .nav-pills > li > a {
          padding-right: 12px;
          padding-left: 12px;
          margin-right: 2px;
          line-height: 14px;
          }

          .nav-tabs {
          border-bottom: 1px solid #ddd;
          }

          .nav-tabs > li {
          margin-bottom: -1px;
          }

          .nav-tabs > li > a {
          padding-top: 8px;
          padding-bottom: 8px;
          line-height: 20px;
          border: 1px solid transparent;
          -webkit-border-radius: 4px 4px 0 0;
          -moz-border-radius: 4px 4px 0 0;
          border-radius: 4px 4px 0 0;
          }

          .nav-tabs > li > a:hover,
          .nav-tabs > li > a:focus {
          border-color: #eeeeee #eeeeee #dddddd;
          }

          .nav-tabs > .active > a,
          .nav-tabs > .active > a:hover,
          .nav-tabs > .active > a:focus {
          color: #555555;
          cursor: default;
          background-color: #ffffff;
          border: 1px solid #ddd;
          border-bottom-color: transparent;
          }

          .nav-pills > li > a {
          padding-top: 8px;
          padding-bottom: 8px;
          margin-top: 2px;
          margin-bottom: 2px;
          -webkit-border-radius: 5px;
          -moz-border-radius: 5px;
          border-radius: 5px;
          }

          .nav-pills > .active > a,
          .nav-pills > .active > a:hover,
          .nav-pills > .active > a:focus {
          color: #ffffff;
          background-color: #d35400;
          /*background-color: #0088cc;*/
          }

          .nav-stacked > li {
          float: none;
          }

          .nav-stacked > li > a {
          margin-right: 0;
          }

          .nav-tabs.nav-stacked {
          border-bottom: 0;
          }

          .nav-tabs.nav-stacked > li > a {
          border: 1px solid #ddd;
          -webkit-border-radius: 0;
          -moz-border-radius: 0;
          border-radius: 0;
          }

          .nav-tabs.nav-stacked > li:first-child > a {
          -webkit-border-top-right-radius: 4px;
          border-top-right-radius: 4px;
          -webkit-border-top-left-radius: 4px;
          border-top-left-radius: 4px;
          -moz-border-radius-topright: 4px;
          -moz-border-radius-topleft: 4px;
          }

          .nav-tabs.nav-stacked > li:last-child > a {
          -webkit-border-bottom-right-radius: 4px;
          border-bottom-right-radius: 4px;
          -webkit-border-bottom-left-radius: 4px;
          border-bottom-left-radius: 4px;
          -moz-border-radius-bottomright: 4px;
          -moz-border-radius-bottomleft: 4px;
          }

          .nav-tabs.nav-stacked > li > a:hover,
          .nav-tabs.nav-stacked > li > a:focus {
          z-index: 2;
          border-color: #ddd;
          }

          .nav-pills.nav-stacked > li > a {
          margin-bottom: 3px;
          }

          .nav-pills.nav-stacked > li:last-child > a {
          margin-bottom: 1px;
          }

          .nav-tabs .dropdown-menu {
          -webkit-border-radius: 0 0 6px 6px;
          -moz-border-radius: 0 0 6px 6px;
          border-radius: 0 0 6px 6px;
          }

          .nav-pills .dropdown-menu {
          -webkit-border-radius: 6px;
          -moz-border-radius: 6px;
          border-radius: 6px;
          }

          .nav .dropdown-toggle .caret {
          margin-top: 6px;
          border-top-color: #0088cc;
          border-bottom-color: #0088cc;
          }

          .nav .dropdown-toggle:hover .caret,
          .nav .dropdown-toggle:focus .caret {
          border-top-color: #005580;
          border-bottom-color: #005580;
          }

          /* move down carets for tabs */

          .nav-tabs .dropdown-toggle .caret {
          margin-top: 8px;
          }

          .nav .active .dropdown-toggle .caret {
          border-top-color: #fff;
          border-bottom-color: #fff;
          }

          .nav-tabs .active .dropdown-toggle .caret {
          border-top-color: #555555;
          border-bottom-color: #555555;
          }

          .nav > .dropdown.active > a:hover,
          .nav > .dropdown.active > a:focus {
          cursor: pointer;
          }

          .nav-tabs .open .dropdown-toggle,
          .nav-pills .open .dropdown-toggle,
          .nav > li.dropdown.open.active > a:hover,
          .nav > li.dropdown.open.active > a:focus {
          color: #ffffff;
          background-color: #999999;
          border-color: #999999;
          }

          .nav li.dropdown.open .caret,
          .nav li.dropdown.open.active .caret,
          .nav li.dropdown.open a:hover .caret,
          .nav li.dropdown.open a:focus .caret {
          border-top-color: #ffffff;
          border-bottom-color: #ffffff;
          opacity: 1;
          filter: alpha(opacity=100);
          }

          .tabs-stacked .open > a:hover,
          .tabs-stacked .open > a:focus {
          border-color: #999999;
          }

          .tabbable {
          *zoom: 1;
          }

          .tabbable:before,
          .tabbable:after {
          display: table;
          line-height: 0;
          content: "";
          }

          .tabbable:after {
          clear: both;
          }

          .tab-content {
          overflow: auto;
          }

          .tabs-below > .nav-tabs,
          .tabs-right > .nav-tabs,
          .tabs-left > .nav-tabs {
          border-bottom: 0;
          }

          .tab-content > .tab-pane,
          .pill-content > .pill-pane {
          display: none;
          }

          .tab-content > .active,
          .pill-content > .active {
          display: block;
          }

          .tabs-below > .nav-tabs {
          border-top: 1px solid #ddd;
          }

          .tabs-below > .nav-tabs > li {
          margin-top: -1px;
          margin-bottom: 0;
          }

          .tabs-below > .nav-tabs > li > a {
          -webkit-border-radius: 0 0 4px 4px;
          -moz-border-radius: 0 0 4px 4px;
          border-radius: 0 0 4px 4px;
          }

          .tabs-below > .nav-tabs > li > a:hover,
          .tabs-below > .nav-tabs > li > a:focus {
          border-top-color: #ddd;
          border-bottom-color: transparent;
          }

          .tabs-below > .nav-tabs > .active > a,
          .tabs-below > .nav-tabs > .active > a:hover,
          .tabs-below > .nav-tabs > .active > a:focus {
          border-color: transparent #ddd #ddd #ddd;
          }

          .tabs-left > .nav-tabs > li,
          .tabs-right > .nav-tabs > li {
          float: none;
          }

          .tabs-left > .nav-tabs > li > a,
          .tabs-right > .nav-tabs > li > a {
          min-width: 74px;
          margin-right: 0;
          margin-bottom: 3px;
          }

          .tabs-left > .nav-tabs {
          float: left;
          margin-right: 19px;
          border-right: 1px solid #ddd;
          }

          .tabs-left > .nav-tabs > li > a {
          margin-right: -1px;
          -webkit-border-radius: 4px 0 0 4px;
          -moz-border-radius: 4px 0 0 4px;
          border-radius: 4px 0 0 4px;
          }

          .tabs-left > .nav-tabs > li > a:hover,
          .tabs-left > .nav-tabs > li > a:focus {
          border-color: #eeeeee #dddddd #eeeeee #eeeeee;
          }

          .tabs-left > .nav-tabs .active > a,
          .tabs-left > .nav-tabs .active > a:hover,
          .tabs-left > .nav-tabs .active > a:focus {
          border-color: #ddd transparent #ddd #ddd;
          *border-right-color: #ffffff;
          }

          .tabs-right > .nav-tabs {
          float: right;
          margin-left: 19px;
          border-left: 1px solid #ddd;
          }

          .tabs-right > .nav-tabs > li > a {
          margin-left: -1px;
          -webkit-border-radius: 0 4px 4px 0;
          -moz-border-radius: 0 4px 4px 0;
          border-radius: 0 4px 4px 0;
          }

          .tabs-right > .nav-tabs > li > a:hover,
          .tabs-right > .nav-tabs > li > a:focus {
          border-color: #eeeeee #eeeeee #eeeeee #dddddd;
          }

          .tabs-right > .nav-tabs .active > a,
          .tabs-right > .nav-tabs .active > a:hover,
          .tabs-right > .nav-tabs .active > a:focus {
          border-color: #ddd #ddd #ddd transparent;
          *border-left-color: #ffffff;
          }

          .nav > .disabled > a {
          color: #999999;
          }

          .nav > .disabled > a:hover,
          .nav > .disabled > a:focus {
          text-decoration: none;
          cursor: default;
          background-color: transparent;
          }

          .navbar {
          *position: relative;
          *z-index: 2;
          margin-bottom: 20px;
          overflow: visible;
          }

          .navbar-inner {
          min-height: 40px;
          padding-right: 20px;
          padding-left: 20px;
          background-color: #fafafa;
          background-image: -moz-linear-gradient(top, #ffffff, #f2f2f2);
          background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#ffffff), to(#f2f2f2));
          background-image: -webkit-linear-gradient(top, #ffffff, #f2f2f2);
          background-image: -o-linear-gradient(top, #ffffff, #f2f2f2);
          background-image: linear-gradient(to bottom, #ffffff, #f2f2f2);
          background-repeat: repeat-x;
          border: 1px solid #d4d4d4;
          -webkit-border-radius: 4px;
          -moz-border-radius: 4px;
          border-radius: 4px;
          filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ffffffff', endColorstr='#fff2f2f2', GradientType=0);
          *zoom: 1;
          -webkit-box-shadow: 0 1px 4px rgba(0, 0, 0, 0.065);
          -moz-box-shadow: 0 1px 4px rgba(0, 0, 0, 0.065);
          box-shadow: 0 1px 4px rgba(0, 0, 0, 0.065);
          }

          .navbar-inner:before,
          .navbar-inner:after {
          display: table;
          line-height: 0;
          content: "";
          }

          .navbar-inner:after {
          clear: both;
          }

          .navbar .container {
          width: auto;
          }

          .nav-collapse.collapse {
          height: auto;
          overflow: visible;
          }

          .navbar .brand {
          display: block;
          float: left;
          padding: 10px 20px 10px;
          margin-left: -20px;
          font-size: 20px;
          font-weight: 200;
          color: #777777;
          text-shadow: 0 1px 0 #ffffff;
          }

          .navbar .brand:hover,
          .navbar .brand:focus {
          text-decoration: none;
          }

          .navbar-text {
          margin-bottom: 0;
          line-height: 40px;
          color: #777777;
          }

          .navbar-link {
          color: #777777;
          }

          .navbar-link:hover,
          .navbar-link:focus {
          color: #333333;
          }

          .navbar .divider-vertical {
          height: 40px;
          margin: 0 9px;
          border-right: 1px solid #ffffff;
          border-left: 1px solid #f2f2f2;
          }

          .navbar .btn,
          .navbar .btn-group {
          margin-top: 5px;
          }

          .navbar .btn-group .btn,
          .navbar .input-prepend .btn,
          .navbar .input-append .btn,
          .navbar .input-prepend .btn-group,
          .navbar .input-append .btn-group {
          margin-top: 0;
          }

          .navbar-form {
          margin-bottom: 0;
          *zoom: 1;
          }

          .navbar-form:before,
          .navbar-form:after {
          display: table;
          line-height: 0;
          content: "";
          }

          .navbar-form:after {
          clear: both;
          }

          .navbar-form input,
          .navbar-form select,
          .navbar-form .radio,
          .navbar-form .checkbox {
          margin-top: 5px;
          }

          .navbar-form input,
          .navbar-form select,
          .navbar-form .btn {
          display: inline-block;
          margin-bottom: 0;
          }

          .navbar-form input[type="image"],
          .navbar-form input[type="checkbox"],
          .navbar-form input[type="radio"] {
          margin-top: 3px;
          }

          .navbar-form .input-append,
          .navbar-form .input-prepend {
          margin-top: 5px;
          white-space: nowrap;
          }

          .navbar-form .input-append input,
          .navbar-form .input-prepend input {
          margin-top: 0;
          }

          .navbar-search {
          position: relative;
          float: left;
          margin-top: 5px;
          margin-bottom: 0;
          }

          .navbar-search .search-query {
          padding: 4px 14px;
          margin-bottom: 0;
          font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
          font-size: 13px;
          font-weight: normal;
          line-height: 1;
          -webkit-border-radius: 15px;
          -moz-border-radius: 15px;
          border-radius: 15px;
          }

          .navbar-static-top {
          position: static;
          margin-bottom: 0;
          }

          .navbar-static-top .navbar-inner {
          -webkit-border-radius: 0;
          -moz-border-radius: 0;
          border-radius: 0;
          }

          .navbar-fixed-top,
          .navbar-fixed-bottom {
          position: fixed;
          right: 0;
          left: 0;
          z-index: 1030;
          margin-bottom: 0;
          }

          .navbar-fixed-top .navbar-inner,
          .navbar-static-top .navbar-inner {
          border-width: 0 0 1px;
          }

          .navbar-fixed-bottom .navbar-inner {
          border-width: 1px 0 0;
          }

          .navbar-fixed-top .navbar-inner,
          .navbar-fixed-bottom .navbar-inner {
          padding-right: 0;
          padding-left: 0;
          -webkit-border-radius: 0;
          -moz-border-radius: 0;
          border-radius: 0;
          }

          .navbar-static-top .container,
          .navbar-fixed-top .container,
          .navbar-fixed-bottom .container {
          width: 940px;
          }

          .navbar-fixed-top {
          top: 0;
          }

          .navbar-fixed-top .navbar-inner,
          .navbar-static-top .navbar-inner {
          -webkit-box-shadow: 0 1px 10px rgba(0, 0, 0, 0.1);
          -moz-box-shadow: 0 1px 10px rgba(0, 0, 0, 0.1);
          box-shadow: 0 1px 10px rgba(0, 0, 0, 0.1);
          }

          .navbar-fixed-bottom {
          bottom: 0;
          }

          .navbar-fixed-bottom .navbar-inner {
          -webkit-box-shadow: 0 -1px 10px rgba(0, 0, 0, 0.1);
          -moz-box-shadow: 0 -1px 10px rgba(0, 0, 0, 0.1);
          box-shadow: 0 -1px 10px rgba(0, 0, 0, 0.1);
          }

          .navbar .nav {
          position: relative;
          left: 0;
          display: block;
          float: left;
          margin: 0 10px 0 0;
          }

          .navbar .nav.pull-right {
          float: right;
          margin-right: 0;
          }

          .navbar .nav > li {
          float: left;
          }

          .navbar .nav > li > a {
          float: none;
          padding: 10px 15px 10px;
          color: #777777;
          text-decoration: none;
          text-shadow: 0 1px 0 #ffffff;
          }

          .navbar .nav .dropdown-toggle .caret {
          margin-top: 8px;
          }

          .navbar .nav > li > a:focus,
          .navbar .nav > li > a:hover {
          color: #333333;
          text-decoration: none;
          background-color: transparent;
          }

          .navbar .nav > .active > a,
          .navbar .nav > .active > a:hover,
          .navbar .nav > .active > a:focus {
          color: #555555;
          text-decoration: none;
          background-color: #e5e5e5;
          -webkit-box-shadow: inset 0 3px 8px rgba(0, 0, 0, 0.125);
          -moz-box-shadow: inset 0 3px 8px rgba(0, 0, 0, 0.125);
          box-shadow: inset 0 3px 8px rgba(0, 0, 0, 0.125);
          }

          .navbar .btn-navbar {
          display: none;
          float: right;
          padding: 7px 10px;
          margin-right: 5px;
          margin-left: 5px;
          color: #ffffff;
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
          background-color: #ededed;
          *background-color: #e5e5e5;
          background-image: -moz-linear-gradient(top, #f2f2f2, #e5e5e5);
          background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#f2f2f2), to(#e5e5e5));
          background-image: -webkit-linear-gradient(top, #f2f2f2, #e5e5e5);
          background-image: -o-linear-gradient(top, #f2f2f2, #e5e5e5);
          background-image: linear-gradient(to bottom, #f2f2f2, #e5e5e5);
          background-repeat: repeat-x;
          border-color: #e5e5e5 #e5e5e5 #bfbfbf;
          border-color: rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.25);
          filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#fff2f2f2', endColorstr='#ffe5e5e5', GradientType=0);
          filter: progid:DXImageTransform.Microsoft.gradient(enabled=false);
          -webkit-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.1), 0 1px 0 rgba(255, 255, 255, 0.075);
          -moz-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.1), 0 1px 0 rgba(255, 255, 255, 0.075);
          box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.1), 0 1px 0 rgba(255, 255, 255, 0.075);
          }

          .navbar .btn-navbar:hover,
          .navbar .btn-navbar:focus,
          .navbar .btn-navbar:active,
          .navbar .btn-navbar.active,
          .navbar .btn-navbar.disabled,
          .navbar .btn-navbar[disabled] {
          color: #ffffff;
          background-color: #e5e5e5;
          *background-color: #d9d9d9;
          }

          .navbar .btn-navbar:active,
          .navbar .btn-navbar.active {
          background-color: #cccccc \9;
          }

          .navbar .btn-navbar .icon-bar {
          display: block;
          width: 18px;
          height: 2px;
          background-color: #f5f5f5;
          -webkit-border-radius: 1px;
          -moz-border-radius: 1px;
          border-radius: 1px;
          -webkit-box-shadow: 0 1px 0 rgba(0, 0, 0, 0.25);
          -moz-box-shadow: 0 1px 0 rgba(0, 0, 0, 0.25);
          box-shadow: 0 1px 0 rgba(0, 0, 0, 0.25);
          }

          .btn-navbar .icon-bar + .icon-bar {
          margin-top: 3px;
          }

          .navbar .nav > li > .dropdown-menu:before {
          position: absolute;
          top: -7px;
          left: 9px;
          display: inline-block;
          border-right: 7px solid transparent;
          border-bottom: 7px solid #ccc;
          border-left: 7px solid transparent;
          border-bottom-color: rgba(0, 0, 0, 0.2);
          content: '';
          }

          .navbar .nav > li > .dropdown-menu:after {
          position: absolute;
          top: -6px;
          left: 10px;
          display: inline-block;
          border-right: 6px solid transparent;
          border-bottom: 6px solid #ffffff;
          border-left: 6px solid transparent;
          content: '';
          }

          .navbar-fixed-bottom .nav > li > .dropdown-menu:before {
          top: auto;
          bottom: -7px;
          border-top: 7px solid #ccc;
          border-bottom: 0;
          border-top-color: rgba(0, 0, 0, 0.2);
          }

          .navbar-fixed-bottom .nav > li > .dropdown-menu:after {
          top: auto;
          bottom: -6px;
          border-top: 6px solid #ffffff;
          border-bottom: 0;
          }

          .navbar .nav li.dropdown > a:hover .caret,
          .navbar .nav li.dropdown > a:focus .caret {
          border-top-color: #333333;
          border-bottom-color: #333333;
          }

          .navbar .nav li.dropdown.open > .dropdown-toggle,
          .navbar .nav li.dropdown.active > .dropdown-toggle,
          .navbar .nav li.dropdown.open.active > .dropdown-toggle {
          color: #555555;
          background-color: #e5e5e5;
          }

          .navbar .nav li.dropdown > .dropdown-toggle .caret {
          border-top-color: #777777;
          border-bottom-color: #777777;
          }

          .navbar .nav li.dropdown.open > .dropdown-toggle .caret,
          .navbar .nav li.dropdown.active > .dropdown-toggle .caret,
          .navbar .nav li.dropdown.open.active > .dropdown-toggle .caret {
          border-top-color: #555555;
          border-bottom-color: #555555;
          }

          .navbar .pull-right > li > .dropdown-menu,
          .navbar .nav > li > .dropdown-menu.pull-right {
          right: 0;
          left: auto;
          }

          .navbar .pull-right > li > .dropdown-menu:before,
          .navbar .nav > li > .dropdown-menu.pull-right:before {
          right: 12px;
          left: auto;
          }

          .navbar .pull-right > li > .dropdown-menu:after,
          .navbar .nav > li > .dropdown-menu.pull-right:after {
          right: 13px;
          left: auto;
          }

          .navbar .pull-right > li > .dropdown-menu .dropdown-menu,
          .navbar .nav > li > .dropdown-menu.pull-right .dropdown-menu {
          right: 100%;
          left: auto;
          margin-right: -1px;
          margin-left: 0;
          -webkit-border-radius: 6px 0 6px 6px;
          -moz-border-radius: 6px 0 6px 6px;
          border-radius: 6px 0 6px 6px;
          }

          .navbar-inverse .navbar-inner {
          background-color: #1b1b1b;
          background-image: -moz-linear-gradient(top, #222222, #111111);
          background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#222222), to(#111111));
          background-image: -webkit-linear-gradient(top, #222222, #111111);
          background-image: -o-linear-gradient(top, #222222, #111111);
          background-image: linear-gradient(to bottom, #222222, #111111);
          background-repeat: repeat-x;
          border-color: #252525;
          filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ff222222', endColorstr='#ff111111', GradientType=0);
          }

          .navbar-inverse .brand,
          .navbar-inverse .nav > li > a {
          color: #999999;
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
          }

          .navbar-inverse .brand:hover,
          .navbar-inverse .nav > li > a:hover,
          .navbar-inverse .brand:focus,
          .navbar-inverse .nav > li > a:focus {
          color: #ffffff;
          }

          .navbar-inverse .brand {
          color: #999999;
          }

          .navbar-inverse .navbar-text {
          color: #999999;
          }

          .navbar-inverse .nav > li > a:focus,
          .navbar-inverse .nav > li > a:hover {
          color: #ffffff;
          background-color: transparent;
          }

          .navbar-inverse .nav .active > a,
          .navbar-inverse .nav .active > a:hover,
          .navbar-inverse .nav .active > a:focus {
          color: #ffffff;
          background-color: #111111;
          }

          .navbar-inverse .navbar-link {
          color: #999999;
          }

          .navbar-inverse .navbar-link:hover,
          .navbar-inverse .navbar-link:focus {
          color: #ffffff;
          }

          .navbar-inverse .divider-vertical {
          border-right-color: #222222;
          border-left-color: #111111;
          }

          .navbar-inverse .nav li.dropdown.open > .dropdown-toggle,
          .navbar-inverse .nav li.dropdown.active > .dropdown-toggle,
          .navbar-inverse .nav li.dropdown.open.active > .dropdown-toggle {
          color: #ffffff;
          background-color: #111111;
          }

          .navbar-inverse .nav li.dropdown > a:hover .caret,
          .navbar-inverse .nav li.dropdown > a:focus .caret {
          border-top-color: #ffffff;
          border-bottom-color: #ffffff;
          }

          .navbar-inverse .nav li.dropdown > .dropdown-toggle .caret {
          border-top-color: #999999;
          border-bottom-color: #999999;
          }

          .navbar-inverse .nav li.dropdown.open > .dropdown-toggle .caret,
          .navbar-inverse .nav li.dropdown.active > .dropdown-toggle .caret,
          .navbar-inverse .nav li.dropdown.open.active > .dropdown-toggle .caret {
          border-top-color: #ffffff;
          border-bottom-color: #ffffff;
          }

          .navbar-inverse .navbar-search .search-query {
          color: #ffffff;
          background-color: #515151;
          border-color: #111111;
          -webkit-box-shadow: inset 0 1px 2px rgba(0, 0, 0, 0.1), 0 1px 0 rgba(255, 255, 255, 0.15);
          -moz-box-shadow: inset 0 1px 2px rgba(0, 0, 0, 0.1), 0 1px 0 rgba(255, 255, 255, 0.15);
          box-shadow: inset 0 1px 2px rgba(0, 0, 0, 0.1), 0 1px 0 rgba(255, 255, 255, 0.15);
          -webkit-transition: none;
          -moz-transition: none;
          -o-transition: none;
          transition: none;
          }

          .navbar-inverse .navbar-search .search-query:-moz-placeholder {
          color: #cccccc;
          }

          .navbar-inverse .navbar-search .search-query:-ms-input-placeholder {
          color: #cccccc;
          }

          .navbar-inverse .navbar-search .search-query::-webkit-input-placeholder {
          color: #cccccc;
          }

          .navbar-inverse .navbar-search .search-query:focus,
          .navbar-inverse .navbar-search .search-query.focused {
          padding: 5px 15px;
          color: #333333;
          text-shadow: 0 1px 0 #ffffff;
          background-color: #ffffff;
          border: 0;
          outline: 0;
          -webkit-box-shadow: 0 0 3px rgba(0, 0, 0, 0.15);
          -moz-box-shadow: 0 0 3px rgba(0, 0, 0, 0.15);
          box-shadow: 0 0 3px rgba(0, 0, 0, 0.15);
          }

          .navbar-inverse .btn-navbar {
          color: #ffffff;
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
          background-color: #0e0e0e;
          *background-color: #040404;
          background-image: -moz-linear-gradient(top, #151515, #040404);
          background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#151515), to(#040404));
          background-image: -webkit-linear-gradient(top, #151515, #040404);
          background-image: -o-linear-gradient(top, #151515, #040404);
          background-image: linear-gradient(to bottom, #151515, #040404);
          background-repeat: repeat-x;
          border-color: #040404 #040404 #000000;
          border-color: rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.25);
          filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ff151515', endColorstr='#ff040404', GradientType=0);
          filter: progid:DXImageTransform.Microsoft.gradient(enabled=false);
          }

          .navbar-inverse .btn-navbar:hover,
          .navbar-inverse .btn-navbar:focus,
          .navbar-inverse .btn-navbar:active,
          .navbar-inverse .btn-navbar.active,
          .navbar-inverse .btn-navbar.disabled,
          .navbar-inverse .btn-navbar[disabled] {
          color: #ffffff;
          background-color: #040404;
          *background-color: #000000;
          }

          .navbar-inverse .btn-navbar:active,
          .navbar-inverse .btn-navbar.active {
          background-color: #000000 \9;
          }

          .breadcrumb {
          padding: 8px 15px;
          margin: 0 0 20px;
          list-style: none;
          background-color: #f5f5f5;
          -webkit-border-radius: 4px;
          -moz-border-radius: 4px;
          border-radius: 4px;
          }

          .breadcrumb > li {
          display: inline-block;
          *display: inline;
          text-shadow: 0 1px 0 #ffffff;
          *zoom: 1;
          }

          .breadcrumb > li > .divider {
          padding: 0 5px;
          color: #ccc;
          }

          .breadcrumb > .active {
          color: #999999;
          }

          .pagination {
          margin: 20px 0;
          }

          .pagination ul {
          display: inline-block;
          *display: inline;
          margin-bottom: 0;
          margin-left: 0;
          -webkit-border-radius: 4px;
          -moz-border-radius: 4px;
          border-radius: 4px;
          *zoom: 1;
          -webkit-box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
          -moz-box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
          box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
          }

          .pagination ul > li {
          display: inline;
          }

          .pagination ul > li > a,
          .pagination ul > li > span {
          float: left;
          padding: 4px 12px;
          line-height: 20px;
          text-decoration: none;
          background-color: #ffffff;
          border: 1px solid #dddddd;
          border-left-width: 0;
          }

          .pagination ul > li > a:hover,
          .pagination ul > li > a:focus,
          .pagination ul > .active > a,
          .pagination ul > .active > span {
          background-color: #f5f5f5;
          }

          .pagination ul > .active > a,
          .pagination ul > .active > span {
          color: #999999;
          cursor: default;
          }

          .pagination ul > .disabled > span,
          .pagination ul > .disabled > a,
          .pagination ul > .disabled > a:hover,
          .pagination ul > .disabled > a:focus {
          color: #999999;
          cursor: default;
          background-color: transparent;
          }

          .pagination ul > li:first-child > a,
          .pagination ul > li:first-child > span {
          border-left-width: 1px;
          -webkit-border-bottom-left-radius: 4px;
          border-bottom-left-radius: 4px;
          -webkit-border-top-left-radius: 4px;
          border-top-left-radius: 4px;
          -moz-border-radius-bottomleft: 4px;
          -moz-border-radius-topleft: 4px;
          }

          .pagination ul > li:last-child > a,
          .pagination ul > li:last-child > span {
          -webkit-border-top-right-radius: 4px;
          border-top-right-radius: 4px;
          -webkit-border-bottom-right-radius: 4px;
          border-bottom-right-radius: 4px;
          -moz-border-radius-topright: 4px;
          -moz-border-radius-bottomright: 4px;
          }

          .pagination-centered {
          text-align: center;
          }

          .pagination-right {
          text-align: right;
          }

          .pagination-large ul > li > a,
          .pagination-large ul > li > span {
          padding: 11px 19px;
          font-size: 17.5px;
          }

          .pagination-large ul > li:first-child > a,
          .pagination-large ul > li:first-child > span {
          -webkit-border-bottom-left-radius: 6px;
          border-bottom-left-radius: 6px;
          -webkit-border-top-left-radius: 6px;
          border-top-left-radius: 6px;
          -moz-border-radius-bottomleft: 6px;
          -moz-border-radius-topleft: 6px;
          }

          .pagination-large ul > li:last-child > a,
          .pagination-large ul > li:last-child > span {
          -webkit-border-top-right-radius: 6px;
          border-top-right-radius: 6px;
          -webkit-border-bottom-right-radius: 6px;
          border-bottom-right-radius: 6px;
          -moz-border-radius-topright: 6px;
          -moz-border-radius-bottomright: 6px;
          }

          .pagination-mini ul > li:first-child > a,
          .pagination-small ul > li:first-child > a,
          .pagination-mini ul > li:first-child > span,
          .pagination-small ul > li:first-child > span {
          -webkit-border-bottom-left-radius: 3px;
          border-bottom-left-radius: 3px;
          -webkit-border-top-left-radius: 3px;
          border-top-left-radius: 3px;
          -moz-border-radius-bottomleft: 3px;
          -moz-border-radius-topleft: 3px;
          }

          .pagination-mini ul > li:last-child > a,
          .pagination-small ul > li:last-child > a,
          .pagination-mini ul > li:last-child > span,
          .pagination-small ul > li:last-child > span {
          -webkit-border-top-right-radius: 3px;
          border-top-right-radius: 3px;
          -webkit-border-bottom-right-radius: 3px;
          border-bottom-right-radius: 3px;
          -moz-border-radius-topright: 3px;
          -moz-border-radius-bottomright: 3px;
          }

          .pagination-small ul > li > a,
          .pagination-small ul > li > span {
          padding: 2px 10px;
          font-size: 11.9px;
          }

          .pagination-mini ul > li > a,
          .pagination-mini ul > li > span {
          padding: 0 6px;
          font-size: 10.5px;
          }

          .pager {
          margin: 20px 0;
          text-align: center;
          list-style: none;
          *zoom: 1;
          }

          .pager:before,
          .pager:after {
          display: table;
          line-height: 0;
          content: "";
          }

          .pager:after {
          clear: both;
          }

          .pager li {
          display: inline;
          }

          .pager li > a,
          .pager li > span {
          display: inline-block;
          padding: 5px 14px;
          background-color: #fff;
          border: 1px solid #ddd;
          -webkit-border-radius: 15px;
          -moz-border-radius: 15px;
          border-radius: 15px;
          }

          .pager li > a:hover,
          .pager li > a:focus {
          text-decoration: none;
          background-color: #f5f5f5;
          }

          .pager .next > a,
          .pager .next > span {
          float: right;
          }

          .pager .previous > a,
          .pager .previous > span {
          float: left;
          }

          .pager .disabled > a,
          .pager .disabled > a:hover,
          .pager .disabled > a:focus,
          .pager .disabled > span {
          color: #999999;
          cursor: default;
          background-color: #fff;
          }

          .modal-backdrop {
          position: fixed;
          top: 0;
          right: 0;
          bottom: 0;
          left: 0;
          z-index: 1040;
          background-color: #000000;
          }

          .modal-backdrop.fade {
          opacity: 0;
          }

          .modal-backdrop,
          .modal-backdrop.fade.in {
          opacity: 0.8;
          filter: alpha(opacity=80);
          }

          .modal {
          position: fixed;
          top: 10%;
          left: 50%;
          z-index: 1050;
          width: 560px;
          margin-left: -280px;
          background-color: #ffffff;
          border: 1px solid #999;
          border: 1px solid rgba(0, 0, 0, 0.3);
          *border: 1px solid #999;
          -webkit-border-radius: 6px;
          -moz-border-radius: 6px;
          border-radius: 6px;
          outline: none;
          -webkit-box-shadow: 0 3px 7px rgba(0, 0, 0, 0.3);
          -moz-box-shadow: 0 3px 7px rgba(0, 0, 0, 0.3);
          box-shadow: 0 3px 7px rgba(0, 0, 0, 0.3);
          -webkit-background-clip: padding-box;
          -moz-background-clip: padding-box;
          background-clip: padding-box;
          }

          .modal.fade {
          top: -25%;
          -webkit-transition: opacity 0.3s linear, top 0.3s ease-out;
          -moz-transition: opacity 0.3s linear, top 0.3s ease-out;
          -o-transition: opacity 0.3s linear, top 0.3s ease-out;
          transition: opacity 0.3s linear, top 0.3s ease-out;
          }

          .modal.fade.in {
          top: 10%;
          }

          .modal-header {
          padding: 9px 15px;
          border-bottom: 1px solid #eee;
          }

          .modal-header .close {
          margin-top: 2px;
          }

          .modal-header h3 {
          margin: 0;
          line-height: 30px;
          }

          .modal-body {
          position: relative;
          max-height: 400px;
          padding: 15px;
          overflow-y: auto;
          }

          .modal-form {
          margin-bottom: 0;
          }

          .modal-footer {
          padding: 14px 15px 15px;
          margin-bottom: 0;
          text-align: right;
          background-color: #f5f5f5;
          border-top: 1px solid #ddd;
          -webkit-border-radius: 0 0 6px 6px;
          -moz-border-radius: 0 0 6px 6px;
          border-radius: 0 0 6px 6px;
          *zoom: 1;
          -webkit-box-shadow: inset 0 1px 0 #ffffff;
          -moz-box-shadow: inset 0 1px 0 #ffffff;
          box-shadow: inset 0 1px 0 #ffffff;
          }

          .modal-footer:before,
          .modal-footer:after {
          display: table;
          line-height: 0;
          content: "";
          }

          .modal-footer:after {
          clear: both;
          }

          .modal-footer .btn + .btn {
          margin-bottom: 0;
          margin-left: 5px;
          }

          .modal-footer .btn-group .btn + .btn {
          margin-left: -1px;
          }

          .modal-footer .btn-block + .btn-block {
          margin-left: 0;
          }

          .tooltip {
          position: absolute;
          z-index: 1030;
          display: block;
          font-size: 11px;
          line-height: 1.4;
          opacity: 0;
          filter: alpha(opacity=0);
          visibility: visible;
          }

          .tooltip.in {
          opacity: 0.8;
          filter: alpha(opacity=80);
          }

          .tooltip.top {
          padding: 5px 0;
          margin-top: -3px;
          }

          .tooltip.right {
          padding: 0 5px;
          margin-left: 3px;
          }

          .tooltip.bottom {
          padding: 5px 0;
          margin-top: 3px;
          }

          .tooltip.left {
          padding: 0 5px;
          margin-left: -3px;
          }

          .tooltip-inner {
          max-width: 200px;
          padding: 8px;
          color: #ffffff;
          text-align: center;
          text-decoration: none;
          background-color: #000000;
          -webkit-border-radius: 4px;
          -moz-border-radius: 4px;
          border-radius: 4px;
          }

          .tooltip-arrow {
          position: absolute;
          width: 0;
          height: 0;
          border-color: transparent;
          border-style: solid;
          }

          .tooltip.top .tooltip-arrow {
          bottom: 0;
          left: 50%;
          margin-left: -5px;
          border-top-color: #000000;
          border-width: 5px 5px 0;
          }

          .tooltip.right .tooltip-arrow {
          top: 50%;
          left: 0;
          margin-top: -5px;
          border-right-color: #000000;
          border-width: 5px 5px 5px 0;
          }

          .tooltip.left .tooltip-arrow {
          top: 50%;
          right: 0;
          margin-top: -5px;
          border-left-color: #000000;
          border-width: 5px 0 5px 5px;
          }

          .tooltip.bottom .tooltip-arrow {
          top: 0;
          left: 50%;
          margin-left: -5px;
          border-bottom-color: #000000;
          border-width: 0 5px 5px;
          }

          .label,
          .badge {
          display: inline-block;
          padding: 2px 4px;
          font-size: 11.844px;
          font-weight: bold;
          line-height: 14px;
          color: #ffffff;
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
          white-space: nowrap;
          vertical-align: baseline;
          background-color: #999999;
          }

          .label {
          -webkit-border-radius: 3px;
          -moz-border-radius: 3px;
          border-radius: 3px;
          }

          .badge {
          padding-right: 9px;
          padding-left: 9px;
          -webkit-border-radius: 9px;
          -moz-border-radius: 9px;
          border-radius: 9px;
          }

          .label:empty,
          .badge:empty {
          display: none;
          }

          a.label:hover,
          a.label:focus,
          a.badge:hover,
          a.badge:focus {
          color: #ffffff;
          text-decoration: none;
          cursor: pointer;
          }

          .label-important,
          .badge-important {
          background-color: #b94a48;
          }

          .label-important[href],
          .badge-important[href] {
          background-color: #953b39;
          }

          .label-warning,
          .badge-warning {
          background-color: #f89406;
          }

          .label-warning[href],
          .badge-warning[href] {
          background-color: #c67605;
          }

          .label-success,
          .badge-success {
          background-color: #468847;
          }

          .label-success[href],
          .badge-success[href] {
          background-color: #356635;
          }

          .label-info,
          .badge-info {
          background-color: #3a87ad;
          }

          .label-info[href],
          .badge-info[href] {
          background-color: #2d6987;
          }

          .label-inverse,
          .badge-inverse {
          background-color: #333333;
          }

          .label-inverse[href],
          .badge-inverse[href] {
          background-color: #1a1a1a;
          }

          .btn .label,
          .btn .badge {
          position: relative;
          top: -1px;
          }

          .btn-mini .label,
          .btn-mini .badge {
          top: 0;
          }

          .hero-unit {
          padding: 60px;
          margin-bottom: 30px;
          font-size: 18px;
          font-weight: 200;
          line-height: 30px;
          color: inherit;
          background-color: #eeeeee;
          -webkit-border-radius: 6px;
          -moz-border-radius: 6px;
          border-radius: 6px;
          }

          .hero-unit h1 {
          margin-bottom: 0;
          font-size: 60px;
          line-height: 1;
          letter-spacing: -1px;
          color: inherit;
          }

          .hero-unit li {
          line-height: 30px;
          }

          .pull-right {
          float: right;
          }

          .pull-left {
          float: left;
          }

          /*
          Template Name: Unify - Responsive Bootstrap Template
          Description: Business, Corporate, Portfolio and Blog Theme.
          Version: 1.2
          Author: Html Stream
          Website: http://htmlstream.com/preview/unify
          */

          /*Import Google Fonts*/
          @import url(http://fonts.googleapis.com/css?family=Monda:400,700);
          @import url(http://fonts.googleapis.com/css?family=Open+Sans);

          * {
          border-radius:0 !important;
          }

          body {
          padding:0;
          color:#333;
          font-size:13px;
          line-height:1.6;
          background:#fff;
          }

          p, a, li {
          color:#555;
          line-height:1.6;
          }

          a,
          a:focus,
          a:hover,
          a:active {
          outline:0 !important;
          }
          a:hover {
          color:#e67e22;
          text-decoration:underline;
          }

          h1, h2, h3, h4, h5 {
          color:#555;
          margin-top:5px;
          text-shadow:none;
          text-shadow:0 0 1px #f6f6f6;
          font-weight:normal !important;
          font-family:'Open Sans', sans-serif;
          }
          h1 i, h2 i, h3 i, h4 i, h5 i {
          margin-right:7px;
          }

          /*Block headline*/
          .heading {
          padding:5px 20px 5px 20px;
          border-left:4px solid #27c5f2;
          }

          .headline {
          display:block;
          margin:10px 0 25px 0;
          border-bottom:1px dotted #e4e9f0;
          }
          .headline h3,
          .headline h4 {
          color:#585f69;
          margin:0 0 -2px 0;
          padding-right:10px;
          display:inline-block;
          text-shadow:0 0 1px #f6f6f6;
          border-bottom:2px solid #e67e22;
          }

          /*Purchase*/
          .purchase {
          padding:30px 0 20px;
          box-shadow:inset 0 0 4px #eee;
          background:url(../img/breadcrumbs.png) repeat;
          }
          .purchase .container {
          padding:0 20px;
          }
          .purchase .container .span9 {
          margin-right:20px;
          }
          .purchase span {
          color:#666;
          display:block;
          font-size:32px;
          line-height:35px;
          margin-bottom:12px;
          }
          .purchase a.btn-buy {
          color:#fff;
          font-size:16px;
          cursor:pointer;
          margin-top:22px;
          font-weight:bold;
          border-radius:2px;
          background:#e67e22;
          display:inline-block;
          text-decoration:none;
          padding:12px 28px 9px;
          text-transform:uppercase;
          text-shadow:0 1px 0 #51a00b;
          }
          .purchase a.btn-buy:hover {
          color:#fff;
          background:#68af28;
          text-decoration:none;
          box-shadow:0 0 5px #c0c2c1;
          }

          /*Service*/
          .service {
          margin-bottom:10px;
          padding:15px 15px 10px;
          }
          .service:hover {
          border-radius:2px;
          box-shadow:0 0 8px #ddd;
          background:#fcfcfc;
          -webkit-transition:box-shadow 0.2s ease-in-out;
          -moz-transition:box-shadow 0.2s ease-in-out;
          -o-transition:box-shadow 0.2s ease-in-out;
          transition:box-shadow 0.2s ease-in-out;
          }
          .service:hover i {
          color:#656565;
          }
          .service i {
          float:left;
          padding:10px;
          color:#e67e22;
          font-size:45px;
          text-align:center;
          -webkit-transition:all 0.4s ease-in-out;
          -moz-transition:all 0.4s ease-in-out;
          -o-transition:all 0.4s ease-in-out;
          transition:all 0.4s ease-in-out;
          }
          .service i.icon-cogs {
          font-size:37px;
          }
          .service .desc {
          width:75%;
          float:right;
          }
          .service .desc h4 {
          font-size:22px;
          line-height:25px;
          }

          .ie7 .service .circle i  {
          padding-bottom:45px !important; /*ie7*/
          }

          /*Blockquote*/
          blockquote:hover {
          border-left-color:#e67e22;
          -webkit-transition:all 0.4s ease-in-out;
          -moz-transition:all 0.4s ease-in-out;
          -o-transition:all 0.4s ease-in-out;
          transition:all 0.4s ease-in-out;
          }
          .hero {
          padding:18px;
          margin:20px 0;
          color:#566c8a;
          font-size:16px;
          background:#fcfcfc;
          border-left:4px solid #94c564;
          font-family:'Open Sans', sans-serif;
          }
          .hero h1, .hero p {
          text-shadow:1px 1px 0 #fff;
          }

          .hero-unify p {
          font-size:13px;
          line-height:20px;
          }


          /* Recent Work  */
          .recent-work a {
          text-align:center;
          background:#fcfcfc;
          display:inline-block;
          }

          .recent-work a:hover {
          text-decoration:none;
          }

          .recent-work a:hover strong {
          color:#555;
          }

          .recent-work em.overflow-hidden {
          display:block;
          }

          .recent-work a span {
          display:block;
          padding:10px;
          border-bottom:solid 2px #eee;
          }

          .recent-work a strong {
          color:#555;
          display:block;
          }

          .recent-work a i {
          color:#777;
          }

          .recent-work a img {
          -webkit-transition: all 0.8s ease-in-out;
          -moz-transition: all 0.8s ease-in-out;
          -o-transition: all 0.8s ease-in-out;
          -ms-transition: all 0.8s ease-in-out;
          transition: all 0.8s ease-in-out;
          }

          .recent-work a:hover img {
          opacity:0.8;
          -webkit-transform: scale(1.2) rotate(3deg);
          -moz-transform: scale(1.2) rotate(3deg);
          -o-transform: scale(1.0) rotate(3deg);
          -ms-transform: scale(1.2) rotate(3deg);
          transform: scale(1.2) rotate(3deg);
          }

          .recent-work a:hover span {
          border-bottom:solid 2px #e67e22;
          -webkit-transition:all 0.2s ease-in-out;
          -moz-transition:all 0.3s ease-in-out;
          -o-transition:all 0.2s ease-in-out;
          transition:all 0.3s ease-in-out;
          }

          /* Work */
          .work {
          margin-top:6px;
          }
          .work .details {
          padding:10px;
          }
          .work .caption {
          display:block;
          padding-top:5px;
          color:#585f69 !important;
          font-size:18px !important;
          }
          .work .caption:hover {
          cursor:pointer;
          color:#444 !important;
          text-decoration:underline;
          }

          /* Testimonials */
          .testimonial-body {
          padding:10px;
          margin-top:5px;
          background:#fcfcfc;
          border:1px solid #f5f5f5;
          }
          .testimonial-author{
          padding-top:15px;
          padding-left:20px;
          }
          .testimonial-author .arrow {
          width:0;
          height:0;
          position:absolute;
          margin-top:-16px;
          margin-left:20px;
          border-top:15px solid #fcfcfc;
          border-bottom:15px solid transparent;
          border-right:15px solid transparent;
          }

          .testimonial-author .name {
          color:#585f69;
          font-weight:bold;
          }

          .testimonal-arrow a {
          margin:0;
          top:-22px;
          float:right;
          color:#e67e22;
          font-size:25px;
          position:relative;
          display:inline-block;
          text-decoration: none;
          padding:0 9px !important;
          }
          .testimonal-arrow a:hover {
          color:#fff;
          text-decoration:none;
          background:#e67e22 !important;
          }

          /*Carousel Arrow */
          .carousel-caption {
          padding:10px 15px;
          }
          .carousel-arrow a.carousel-control {
          font-size:40px;
          height:inherit;
          }
          .carousel-arrow a.left {
          left:0;
          }
          .carousel-arrow a.right {
          right:0;
          }

          /*Clients (Flexslider)*/
          .clients {
          box-shadow:none !important;
          margin-bottom:0 !important;
          }
          .clients li {
          float:left;
          overflow:hidden;
          margin-left:1px;
          position:relative;
          background:#fafafa;
          }
          .clients li:hover {
          background:#f6f6f6;
          }
          .clients li img.color-img {
          top:0;
          left:0;
          display:none;
          position:absolute;
          }
          .clients li:hover img.color-img {
          display:block;
          }
          .clients li img {
          filter:gray; /* IE6-9 */
          float:none !important;
          margin:0 auto !important;
          }
          .clients li img:hover {
          filter:none;
          }
          .clients,
          .flexslider.home {
          border:0px;
          overflow:hidden;
          margin-top:10px;
          margin-bottom:30px;
          border-radius:0;
          -moz-border-radius:0;
          -webkit-border-radius:0;
          }

          .flexslider {
          margin-top:10px !important;
          }
          .flexslider .flex-direction-nav a {
          margin-top:-10px !important;
          }

          /*Pegination*/
          .pagination ul {
          box-shadow:none;
          }
          .pagination li a {
          color:#777;
          padding:5px 15px;
          border-radius:0 !important;
          }

          /*Footer*/
          .footer {
          margin-top:40px;
          padding:20px 10px;
          /*background:#585f69;*/
          background:#585f69;
          color:#dadada;
          }
          .footer h1,
          .footer h2,
          .footer h3,
          .footer h4,
          .footer h5 {
          text-shadow:none;
          font-weight:normal !important;
          }
          .footer p,
          .footer a {
          font-size:14px;
          }
          .footer p {
          color:#dadada;
          }
          .footer a {
          color:#e67e22;
          }
          .footer a:hover {
          color:#a8f85f;
          -webkit-transition:all 0.4s ease-in-out;
          -moz-transition:all 0.4s ease-in-out;
          -o-transition:all 0.4s ease-in-out;
          transition:all 0.4s ease-in-out;
          }
          .footer h4,
          .footer h3 {
          color:#e4e4e4;
          background:none;
          text-shadow:none;
          }

          /*Blog Posts*/
          .footer .posts {
          padding:0 15px;
          }
          .footer .blog-list {
          margin:0;
          padding:0;
          color:#dadada;
          list-style:none;
          }
          .footer .blog-list li {
          padding:0 0;
          margin-bottom:7px;
          }
          .footer .blog-list li span {
          color:#818488;
          }
          .footer .dl-horizontal,
          .footer .dl-horizontal:hover {
          border:none !important;
          background:none !important;
          }
          .footer .dl-horizontal a {
          color:#dadada;
          }
          .footer .dl-horizontal a:hover {
          color:#a8f85f !important;
          }
          .footer .dl-horizontal img {
          border-color:#888 !important;
          }

          /*Copyright*/
          .copyright {
          font-size:12px;
          padding:5px 10px;
          background:#3e4753;
          border-top:solid 1px #777;
          }
          .copyright p {
          color:#dadada;
          }
          .copyright a {
          margin:0 5px;
          color:#e67e22;
          }
          .copyright a:hover {
          color:#e67e22;
          -webkit-transition:all 0.4s ease-in-out;
          -moz-transition:all 0.4s ease-in-out;
          -o-transition:all 0.4s ease-in-out;
          transition:all 0.4s ease-in-out;
          }
          .copyright .span8 {
          padding-top:15px;
          }
          .copyright .span4 {
          padding-top:10px;
          }

          /*Home Page "Main page" (Default)
          ------------------------------------*/
          /*Thumbnail*/
          .thumbnail-style {
          padding:5px;
          border-radius:2px;
          }
          .thumbnail-style:hover {
          box-shadow:0 0 8px #ddd;
          -webkit-transition:box-shadow 0.2s ease-in-out;
          -moz-transition:box-shadow 0.2s ease-in-out;
          -o-transition:box-shadow 0.2s ease-in-out;
          transition:box-shadow 0.2s ease-in-out;
          }
          .thumbnail-style h3 {
          margin:5px 0 0 0;
          }
          .thumbnail-style h3 a {
          font-size:20px;
          }
          .thumbnail-style h3 a:hover {
          color:#e67e22;
          text-decoration:none;
          }
          .thumbnail-style .thumbnail-img {
          position:relative;
          }
          .thumbnail-style a.btn-more {
          right:-10px;
          bottom:10px;
          color:#fff;
          padding:1px 6px;
          position:absolute;
          background:#e67e22;
          display:inline-block;
          }
          .thumbnail-style a.btn-more:hover {
          text-decoration:none;
          box-shadow:0 0 0 2px #377500;
          }
          .thumbnail-style:hover a.btn-more {
          right:10px;
          }

          .thumbnail-kenburn img {
          left:10px;
          margin-left:-10px;
          position:relative;
          -webkit-transition: all 0.8s ease-in-out;
          -moz-transition: all 0.8s ease-in-out;
          -o-transition: all 0.8s ease-in-out;
          -ms-transition: all 0.8s ease-in-out;
          transition: all 0.8s ease-in-out;
          }
          .thumbnail-kenburn:hover img {
          -webkit-transform: scale(1.2) rotate(2deg);
          -moz-transform: scale(1.2) rotate(2deg);
          -o-transform: scale(1.2) rotate(2deg);
          -ms-transform: scale(1.2) rotate(2deg);
          transform: scale(1.2) rotate(2deg);
          }

          /*Welcome Block*/
          .servive-block .span4 {
          padding:20px 30px;
          text-align:center;
          margin-bottom:20px;
          background:#fafafa;
          border-radius:2px;
          -webkit-transition:all 0.3s ease-in-out;
          -moz-transition:all 0.3s ease-in-out;
          -o-transition:all 0.3s ease-in-out;
          transition:all 0.3s ease-in-out;
          }
          .servive-block .span4:hover {
          border-radius:2px;
          box-shadow:0 0 8px #ddd;
          }
          .servive-block .span4 h4 a:hover {
          color:#e67e22;
          text-decoration:none;
          }

          .servive-block .span4:hover h4,
          .servive-block .span4:hover i {
          color:#e67e22;
          }
          .servive-block .span4 i {
          color:#565656;
          font-size:40px;
          -webkit-transition:all 0.4s ease-in-out;
          -moz-transition:all 0.4s ease-in-out;
          -o-transition:all 0.4s ease-in-out;
          transition:all 0.4s ease-in-out;
          }
          .servive-block-in .span4 i {
          color:#e67e22;
          }
          .servive-block-in .span4:hover i {
          color:#565656;
          }

          /*Breadcrumbs*/
          .breadcrumbs {
          padding:10px 0 6px;
          box-shadow:inset 0 0 4px #eee;
          background:url(Images/breadcrumbs.png) repeat;
          }
          .breadcrumbs h1 {
          color:#686868;
          font-size:30px;
          text-shadow:0 1px 0 #f1efef;
          }
          .breadcrumbs .container {
          padding:0 15px;
          }

          .breadcrumb {
          top:9px;
          padding-right:30px;
          background:none;
          position:relative;
          }
          .breadcrumb a {
          color:#777;
          }
          .breadcrumb li.active,
          .breadcrumb li a:hover {
          color:#e67e22;
          text-decoration:none;
          }

          /*Home Page "Options"
          ------------------------------------*/
          /*Accardion*/
          .acc-home a.accordion-toggle {
          color:#686868;
          font-size:18px;
          background:none;
          padding:5px 15px;
          background:#fafafa;
          border-bottom:solid 1px #eee;
          text-decoration:none !important;
          }
          .acc-home a.active,
          .acc-home a.accordion-toggle:hover {
          color:#92d556;
          text-decoration:none !important;
          }
          .acc-home .accordion-group {
          border:none;
          margin:0 !important;
          }
          .acc-home .accordion-heading,
          .acc-home .accordion-inner {
          border:none;
          }
          .acc-home .accordion-inner {
          border:none;
          padding-top:3px;
          }
          .acc-home .collapse.in {
          margin-top:-1px;
          margin-bottom:20px;
          background:#fdfdfd;
          border-bottom:solid 1px #e67e22;
          }

          /*Posts*/
          .posts .dl-horizontal {
          margin-bottom:0;
          padding:3px;
          background:#fdfdfd;
          border-right:solid 2px #eee;
          }
          .posts .dl-horizontal:hover {
          border-right:solid 2px #e67e22;
          -webkit-transition:all 0.4s ease-in-out;
          -moz-transition:all 0.4s ease-in-out;
          -o-transition:all 0.4s ease-in-out;
          transition:all 0.4s ease-in-out;
          }
          .posts .dl-horizontal dt {
          width:56px;
          float:left;
          }
          .posts .dl-horizontal dt img {
          width:50px;
          height:50px;
          border:solid 3px #eee;
          }
          .posts .dl-horizontal dd {
          margin-left:66px;
          }
          .posts .dl-horizontal dd p {
          margin:0;
          }
          .posts .dl-horizontal a {
          font-size:15px;
          line-height:14px !important;
          }
          .posts .dl-horizontal a:hover {
          color:#e67e22;
          text-decoration:none;
          }
          .posts .dl-horizontal:hover dt img,
          .posts .dl-horizontal:hover dd a {
          color:#e67e22;
          border-color:#e67e22 !important;
          -webkit-transition:all 0.4s ease-in-out;
          -moz-transition:all 0.4s ease-in-out;
          -o-transition:all 0.4s ease-in-out;
          transition:all 0.4s ease-in-out;
          }

          /*Home Page "Options"
          ------------------------------------*/
          /*Slider*/
          .slider-inner .da-slider {
          box-shadow:none;
          border-bottom:2px solid #ddd;
          }

          /*Carousel*/
          .carousel-control {
          color:#fff;
          border:none;
          margin-top:0;
          border-radius:2px;
          }
          .carousel-control:hover {
          opacity:1;
          /*color:#d35400; */
          background-color:#d35400;
          }

          /*Tabs*/
          .nav-tabs {
          background:none !important;
          }
          .nav-tabs a {
          font-size:14px;
          padding:5px 15px !important;
          }
          .nav-tabs li.active a,
          .nav-tabs li.active a:hover,
          .nav-tabs > .active > a,
          .nav-tabs > .active > a:hover,
          .nav-tabs > .active > a:focus {
          color:#fff;
          border:none;
          background:#e67e22;
          }
          .nav-tabs > li > a {
          border:none;
          border-radius:0;
          }
          .nav-tabs > li > a:hover {
          color:#fff;
          background:#e67e22;
          }
          .tab-content {
          padding:7px 10px;
          border-top:solid 2px #e67e22;
          }

          /*Home Page "Options"
          ------------------------------------*/
          /*Right Sidebar*/
          .who li {
          margin-bottom:6px;
          }
          .who li i {
          color:#e67e22;
          position:relative;
          top:2px;
          margin-right:7px;
          font-size:18px;
          }
          .who li:hover i,
          .who li:hover a {
          color:#777;
          }
          .who li:hover a:hover {
          text-decoration:none;
          }

          /*Home Page "Options"
          ------------------------------------*/
          /*Service Blocks*/
          .service-alternative .service:hover {
          background:#76ca2c;
          -webkit-transition:all 0.4s ease-in-out;
          -moz-transition:all 0.4s ease-in-out;
          -o-transition:all 0.4s ease-in-out;
          transition:all 0.4s ease-in-out;
          }
          .service-alternative .service:hover i,
          .service-alternative .service:hover p,
          .service-alternative .service:hover h4 {
          color:#fff;
          }

          /*About Page
          ------------------------------------*/
          .team ul {
          text-align:right;
          }
          .team ul li {
          padding:0 !important;
          margin:0 !important;
          }
          .team ul li a,
          .team ul li a:hover {
          text-decoration:none;
          }
          .team ul li i {
          color:#aaa;
          font-size:20px;
          padding:4px;
          background:#f7f7f7;
          }
          .team ul li i:hover {
          color:#fff;
          background:#e67e22;
          -webkit-transition:all 0.2s ease-in-out;
          -moz-transition:all 0.2s ease-in-out;
          -o-transition:all 0.2s ease-in-out;
          transition:all 0.2s ease-in-out;
          }
          .team .thumbnail-style {
          padding:12px;
          }
          .team .thumbnail-style small {
          display:block;
          font-size:12px;
          }
          .team .thumbnail-style h3 {
          margin-bottom:10px;
          }
          .team .thumbnail-style:hover h3 a {
          color:#e67e22 !important;
          }

          /*Icons Page
          ------------------------------------*/
          .icon-page li {
          color:#555;
          margin:5px 0;
          font-size:14px;
          font-family:Arial;
          }
          .icon-page li i {
          font-size:14px;
          margin-right:5px;
          }
          .icon-page li:hover {
          color:#e67e22;
          }

          /*Pricing Page
          ------------------------------------*/
          /*Pricing Head*/
          .pricing {
          position:relative;
          border-radius:3px;
          margin-bottom:15px;
          box-shadow:0 0 5px #eee;
          }
          .pricing:hover {
          box-shadow:0 0 15px #b5b5b5;
          }
          .pricing:hover h4 {
          color:#55c931;
          }
          .pricing-head {
          text-align:center;
          }
          .pricing-head h3,
          .pricing-head h4 {
          margin:0;
          line-height:normal;
          font-weight:bold !important;
          }
          .pricing-head h3 span,
          .pricing-head h4 span {
          display:block;
          margin-top:5px;
          font-size:12px;
          font-style:italic;
          }
          .pricing-head h3 {
          color:#fafafa;
          padding:12px 0;
          font-size:35px;
          font-family:Arial;
          background:#55c931;
          border-radius:3px 3px 0 0;
          text-shadow:0 1px 0 #32a20f;
          border-bottom:solid 1px #41b91c;
          }
          .pricing-head h4 {
          color:#bac39f;
          padding:5px 0;
          font-size:70px;
          font-family:Arial;
          background:#fbfef2;
          text-shadow:0 1px 0 #fff;
          border-bottom:solid 1px #f5f9e7;
          }
          .pricing-head h4 i {
          top:-8px;
          font-size:28px;
          font-style:normal;
          position:relative;
          }
          .pricing-head h4 span {
          top:-10px;
          font-size:14px;
          font-style:normal;
          position:relative;
          }

          /*Pricing Content*/
          .pricing-content li {
          color:#888;
          font-size:12px;
          padding:7px 15px;
          border-bottom:solid 1px #f5f9e7;
          }
          .pricing-content li i {
          top:2px;
          color:#e67e22;
          font-size:16px;
          margin-right:5px;
          position:relative;
          }

          /*Pricing Footer*/
          .pricing-footer {
          color:#777;
          font-size:11px;
          line-height:17px;
          text-align:center;
          padding:0 20px 19px;
          border-radius:0 0 3px 3px;
          }
          .pricing-footer a,
          .pricing-footer button {
          color:#fff;
          border:none;
          margin-top:5px;
          font-size:16px;
          padding:6px 15px;
          text-align:center;
          border-radius:2px;
          background:#55c931;
          display:inline-block;
          text-transform:uppercase;
          text-shadow:0 1px 0 #38b312;
          border-bottom:solid 2px #41b91c;
          }
          .pricing-footer a:hover,
          .pricing-footer button:hover {
          cursor:pointer;
          background:#40ba1a;
          text-decoration:none;
          box-shadow:0 0 3px #999;
          }

          /*Priceing Active*/
          .price-active,
          .pricing:hover {
          z-index:9;
          margin-top:-15px;
          box-shadow:0 0 15px #b5b5b5;
          }
          .price-active h4 {
          color:#55c931;
          }

          .no-space-pricing .pricing:hover {
          -webkit-transition:box-shadow 0.3s ease-in-out;
          -moz-transition:box-shadow 0.3s ease-in-out;
          -o-transition:box-shadow 0.3s ease-in-out;
          transition:box-shadow 0.2s ease-in-out;
          }
          .no-space-pricing .price-active .pricing-head h4,
          .no-space-pricing .pricing:hover .pricing-head h4 {
          color:#55c931;
          padding:15px 0;
          font-size:80px;
          -webkit-transition:color 0.5s ease-in-out;
          -moz-transition:color 0.5s ease-in-out;
          -o-transition:color 0.5s ease-in-out;
          transition:color 0.5s ease-in-out;
          }

          /*Gallery Page
          ------------------------------------*/
          .gallery .thumbnail,
          .gallery .thumbnail:hover {
          padding:0;
          border:none;
          box-shadow:none;
          }
          .gallery .thumbnails {
          margin-bottom:6px;
          }

          /*Registration and Login Page
          ------------------------------------*/
          .reg-page,.another-page,
          .login-page  {
          overflow:hidden;
          margin:0 auto;
          background:#fcfcfc;
          border:solid 1px #eee;
          box-shadow:0 0 7px #eee;
          }

          /*Registration*/
          .reg-page {
          min-width:30%;
          max-width:30%;
          padding:30px 50px 30px;
          }
          .reg-page h3 {
          margin-bottom:25px;
          }

          /*another*/
          .another-page {
          min-width:90%;
          max-width:30%;
          padding:20px 50px 30px;
          }
          .another-page h3 {
          margin-bottom:25px;
          }

          /*Login*/
          .login-page {
          min-width:25%;
          max-width:25%;
          padding:35px 30px 30px;
          }
          .login-page h3 {
          margin:0 0 25px 0;
          }
          .login-page input.login-inputs {
          width:86%;
          }
          .login-page .checkbox {
          margin-top:7px;
          }
          .login-page .checkbox input {
          margin-right:6px !important;
          }
          .login-page button {
          margin:0 0 5px 0;
          }

          /*Login Page v1.1*/
          .log-page {
          width: 310px;
          padding: 20px;
          margin: 0 auto;
          background:#fcfcfc;
          border:solid 1px #eee;
          box-shadow:0 0 7px #eee;
          }

          /*404 Page
          ------------------------------------*/
          .page-404 p {
          top:70px;
          color:#777;
          font-size:300px;
          line-height:180px;
          text-align:center;
          position:relative;
          }
          .page-404 p i {
          font-style:normal;
          text-shadow:0 0 3px;
          }
          .page-404 p span {
          display:block;
          font-size:32px;
          position:relative;
          }

          /*Clients Page
          ------------------------------------*/
          .clients-page {
          overflow:hidden;
          }
          .clients-page p {
          overflow:auto;
          }
          .clients-page p a {
          overflow:auto;
          text-decoration:underline;
          }
          .clients-page a.img-hover {
          display:block;
          position:relative;
          }
          .clients-page img {
          float:left;
          margin-right:20px;
          background:#fafafa;
          border:solid 1px #eee;
          width:120px;
          height:120px;
          }
          .clients-page img.img-colorful {
          display:none;
          }
          .clients-page a:hover img.img-colorful,
          .clients-page:hover img.img-colorful {
          top:0;
          left:0;
          display:block;
          position:absolute;
          }

          /*Privacy Page
          ------------------------------------*/
          .privacy {}
          .privacy a {
          text-decoration:underline;
          }
          .privacy a:hover {
          color:#e67e22;
          text-decoration:none;
          }

          /*Portfolio Page
          ------------------------------------*/
          .portfolio-columns .span3 {
          margin-bottom:1.8%;
          }
          .portfolio-columns .span4 {
          margin-bottom:2.3%;
          }
          .portfolio-columns .span6 {
          margin-bottom:2.2%;
          }

          /*Portfolio Item Page
          ------------------------------------*/
          .portfolio-item h3 {
          margin-top:0;
          }
          .portfolio-item li {
          padding:3px 0;
          }
          .portfolio-item p a {
          text-decoration:underline;
          }
          .portfolio-item p a:hover {
          text-decoration:none;
          }

          /*Blog Page
          ------------------------------------*/
          .blog-page ul,
          .blog-page li {
          margin:0 !important;
          padding:0 !important;
          }
          .blog h3 {
          color:#e67e22;
          }
          .blog ul {
          color:#555;
          font-size:12px;
          }
          .blog li {
          margin-right:7px !important;
          }
          .blog li i {
          color:#666;
          }
          .blog li a:hover {
          color:#e67e22;
          text-decoration:none;
          }
          .blog ul.blog-info {
          border-top:solid 1px #eee;
          }
          .blog .blog-img {
          margin:10px 0;
          }

          /*Blog Tags*/
          ul.blog-tags a {
          font-size:13px;
          padding:2px 5px;
          background:#f7f7f7;
          margin:0 2px 5px 0;
          display:inline-block;
          text-shadow:0 1px 0 #fff;
          }
          ul.blog-tags a:hover,
          ul.blog-tags a:hover i {
          color:#e67e22;
          text-decoration:none;
          -webkit-transition:all 0.3s ease-in-out;
          -moz-transition:all 0.3s ease-in-out;
          -o-transition:all 0.3s ease-in-out;
          transition:all 0.3s ease-in-out;
          }
          ul.blog-tags a i {
          color:#777;
          }
          .blog ul.blog-tags {
          border-bottom:solid 1px #eee;
          padding-bottom:4px !important;
          }
          .blog ul.blog-tags a {
          font-size:10px;
          display:inline;
          padding:2px 3px;
          margin-right:2px;
          background:#f4f4f4;
          }

          /*Blog Ads*/
          .blog-ads li {
          display:inline;
          }
          .blog-ads li img {
          opacity:0.6;
          width:60px;
          height:60px;
          margin:0 2px 8px;
          }
          .blog-ads li img:hover {
          opacity:1;
          box-shadow:0 0 0 4px #e67e22;
          }

          /*Blog Latest Tweets*/
          .blog-twitter p {
          }
          .blog-twitter p span {
          color:#777;
          display:block;
          font-size:11px;
          }
          .blog-twitter p a {
          color:#e67e22;
          text-decoration:none;
          }
          .blog-twitter p a:hover {
          text-decoration:underline;
          }

          /*Blog Item Page
          ------------------------------------*/
          .blog-item .media img {
          top:3px;
          width:54px;
          height:54px;
          position:relative;
          }
          .blog-item h4.media-heading {
          position:relative;
          }
          .blog-item h4.media-heading span {
          top:3px;
          right:0;
          color:#777;
          font-size:12px;
          position:absolute;
          }
          .blog-item h4.media-heading span a {
          color:#e67e22;
          }

          /*Contact Page
          ------------------------------------*/
          .map {
          width:100%;
          height:350px;
          border-top:solid 1px #eee;
          border-bottom:solid 1px #eee;
          }

          .map-box {
          height: 250px;
          }

          .map-box-space {
          margin-top: 25px;
          }

          /*Coming Soon Page
          ------------------------------------*/
          .coming-soon-page {
          background: #585f69;
          }

          .coming-soon-border {
          border-top: solid 3px #e67e22;
          }

          .coming-soon-logo  {
          margin-top: 10px;
          padding-top: 15px;
          border-top: solid 1px #4c5159;
          }

          .coming-soon-logo a {
          display: block;
          text-align: center;
          }

          .coming-soon,
          .coming-soon-plugin {
          padding: 20px;
          text-align: center;
          margin-top: 20px;
          }

          .coming-soon-plugin {
          min-height: 260px;
          }

          .coming-soon h1,
          .coming-soon p {
          color: #fff;
          }

          .coming-soon h1 {
          font-size: 50px;
          line-height: 50px;
          margin-bottom: 15px;
          text-shadow: none;
          }

          .coming-soon p {
          font-size: 16px;
          line-height: 22px;
          }

          .coming-soon input {
          box-shadow: none;
          -moz-box-shadow: none;
          -webkit-box-shadow: none;
          }

          .coming-soon-copyright {
          padding: 5px 0;
          }

          .coming-soon-copyright p {
          color: #fff;
          text-align: right;
          }

          /*One Page
          ------------------------------------*/
          .one-page {
          padding-left: 0;
          padding-right: 0;
          }

          .one-page h1,
          .one-page h2 {
          color: #fff;
          font-size: 30px;
          text-shadow: none;
          margin-bottom: 20px;
          }

          .one-page p {
          color: #fff;
          }

          .one-page .one-default p,
          .one-page .one-default h1,
          .one-page .one-default h2,
          .one-page .one-grey p,
          .one-page .one-grey h1,
          .one-page .one-grey h2 {
          color: #555;
          }

          .one-page .one-page-inner {
          padding: 30px 20px;
          min-height: 300px;
          }

          .one-page .one-page-btn {
          font-size: 20px !important;
          padding-left: 30px !important;
          padding-right: 30px !important;
          margin-bottom: 15px;
          }

          .one-page .btn-u {
          margin-bottom: 15px;
          }

          .one-page .one-default {
          background: #fff;
          }
          .one-page .one-grey {
          background: #fafafa;
          }
          .one-page .one-blue {
          background: #3498db;
          }
          .one-page .one-red {
          background: #e74c3c;
          }
          .one-page .one-orange {
          background: #d35400;
          }
          .one-page .one-green {
          background: #2ecc71;
          }

          /*Search Page
          ------------------------------------*/
          .search-page h2 {
          font-size: 28px;
          margin-bottom: 20px;
          }

          .booking-blocks {
          overflow: hidden;
          padding: 15px 20px;
          margin-bottom: 25px;
          background: #fafafa;
          -webkit-transition:all 0.3s ease-in-out;
          -moz-transition:all 0.3s ease-in-out;
          -o-transition:all 0.3s ease-in-out;
          transition:all 0.3s ease-in-out;
          }

          .booking-blocks:hover {
          border-radius:2px;
          background: #fafafa;
          box-shadow:0 0 8px #ddd;
          }

          .booking-blocks p a {
          color: #e67e22;
          }

          .booking-blocks .booking-img {
          width: 140px;
          margin-right: 10px;
          }

          .booking-blocks .booking-img li {
          color: #777;
          }

          .booking-blocks .booking-img li i {
          color: #78ccf8;
          font-size: 12px;
          margin-right: 5px;
          }

          .booking-blocks .booking-img img {
          float: left;
          width: 140px;
          height: auto;
          margin: 5px 10px 10px 0;
          }

          .booking-blocks h2 {
          margin-top: 0;
          font-size: 20px;
          line-height: 20px;
          }

          .booking-blocks ul.inline li {
          padding: 0;
          }

          .booking-blocks ul.inline li i {
          color: #f8be2c;
          cursor: pointer;
          font-size: 16px;
          }

          .booking-blocks ul.inline li i:hover {
          color: #f8be2c;
          }

          /*Others (Global classes)
          ------------------------------------*/
          .color-red { color:#c00;}
          .color-green { color:#e67e22;}
          .color-blue { color:#3498db;}

          .pull-lft { text-align:left;}
          .pull-rgt { text-align:right;}

          .rgt-img-margin { margin:4px 0 5px 8px;}
          .lft-img-margin { margin:5px 20px 5px 0;}

          .overflow-hidden { overflow:hidden;}
          .padding-left-5 { padding-left:5px;}
          .img-width-200 { width:200px;}

          /*Image Border*/
          .img-border {
          border:solid 3px #fff;
          }

          /*Background light-style*/
          .bg-light {
          padding:10px 15px;
          border-radius:3px;
          margin-bottom:10px;
          background:#fcfcfc;
          }
          .bg-light:hover {
          padding:9px 14px;
          border:solid 1px #e5e5e5;
          }

          /*Link read-more*/
          a.read-more {
          font-weight:bold;
          text-decoration:none;
          }
          a.read-more:hover {
          color:#e67e22;
          text-decoration:none;
          }

          /*Link color-green-style*/
          .linked:hover {
          color:#e67e22;
          text-decoration:none;
          }

          /*CSS3 Hover Effects*/
          .hover-effect {
          -webkit-transition:all 0.4s ease-in-out;
          -moz-transition:all 0.4s ease-in-out;
          -o-transition:all 0.4s ease-in-out;
          transition:all 0.4s ease-in-out;
          }
          .hover-effect-kenburn {
          left:10px;
          margin-left:-10px;
          position:relative;
          -webkit-transition: all 0.8s ease-in-out;
          -moz-transition: all 0.8s ease-in-out;
          -o-transition: all 0.8s ease-in-out;
          -ms-transition: all 0.8s ease-in-out;
          transition: all 0.8s ease-in-out;
          }
          .hover-effect-kenburn:hover {
          -webkit-transform: scale(2) rotate(5deg);
          -moz-transform: scale(2) rotate(5deg);
          -o-transform: scale(2) rotate(5deg);
          -ms-transform: scale(2) rotate(5deg);
          transform: scale(2) rotate(5deg);
          }

          /*Spaces*/
          .margin-bottom-5,
          .margin-bottom-10,
          .margin-bottom-20,
          .margin-bottom-20,
          .margin-bottom-25,
          .margin-bottom-40,
          .margin-bottom-50,
          .margin-bottom-60 {
          clear:both;
          }
          .margin-bottom-5 {
          margin-bottom:5px;
          }
          .margin-bottom-10 {
          margin-bottom:10px;
          }
          .margin-bottom-20 {
          margin-bottom:20px;
          }
          .margin-bottom-25 {
          margin-bottom:25px;
          }
          .margin-bottom-30 {
          margin-bottom:30px;
          }
          .margin-bottom-40 {
          margin-bottom:40px;
          }
          .margin-bottom-50 {
          margin-bottom:50px;
          }
          .margin-bottom-60 {
          margin-bottom:60px;
          }

          .top-2 {
          top:2px;
          }

          /*Button Style*/
          .btn {
          box-shadow: none;
          }

          .btn-u {
          border:0;
          font-size:14px;
          cursor:pointer;
          padding:5px 13px;
          position:relative;
          background:#e67e22;
          display:inline-block;
          color:#fff !important;
          text-decoration:none !important;
          }
          .btn-u:hover {
          color:#fff;
          background:#d35400;
          text-decoration:none;
          -webkit-transition:all 0.4s ease-in-out;
          -moz-transition:all 0.4s ease-in-out;
          -o-transition:all 0.4s ease-in-out;
          transition:all 0.4s ease-in-out;
          }

          .btn-u-small {
          padding:3px 12px;
          }
          .btn-u-large {
          font-size:18px;
          padding:10px 25px;
          }
          a.btn-u {
          padding:4px 13px;
          vertical-align:middle;
          }
          a.btn-u-small {
          padding:2px 12px;
          }
          a.btn-u-large {
          font-size:18px;
          padding:6px 25px;
          }

          /*Buttons Color*/
          .btn-u-blue {
          background: #3498db !important;
          }
          .btn-u-blue:hover {
          background: #2980b9 !important;
          }

          .btn-u-red {
          background: #e74c3c !important;
          }
          .btn-u-red:hover {
          background: #c0392b !important;
          }

          .btn-u-orange {
          background: #d35400 !important;
          }
          .btn-u-orange:hover {
          background: #d35400 !important;
          }

          .btn-u-sea {
          background: #1abc9c !important;
          }
          .btn-u-sea:hover {
          background: #16a085 !important;
          }

          .btn-u-green {
          background: #2ecc71 !important;
          }
          .btn-u-green:hover {
          background: #27ae60 !important;
          }

          .btn-u-yellow {
          background: #F1C40F !important;
          }
          .btn-u-yellow:hover {
          background: #F39C12 !important;
          }

          /*Style Switcher*/
          i.style-switcher-btn {
          right: 0;
          top: 37px;
          color: #fff;
          font-size: 18px;
          cursor: pointer;
          z-index: 555555;
          position: fixed;
          padding: 7px 9px;
          background: #585f69;
          }

          i.style-switcher-btn:hover {
          background:#707985;
          }

          i.style-switcher-btn-option {
          top: 38px;
          background: #9097a0;
          }

          i.style-switcher-btn-option:hover {
          background: #707985;
          }

          .style-switcher {
          right: 0;
          top: 37px;
          display: none;
          z-index: 555555;
          position: fixed;
          background: #585f69;
          padding: 15px 15px 15px 20px;
          }

          .style-switcher-inner {
          background: #9097a0;
          }

          .style-switcher .theme-close {
          top: 10px;
          right: 6px;
          position: absolute;
          }

          .style-switcher .theme-close i {
          color: #fff;
          cursor: pointer;
          font-size: 16px;
          padding: 5px 7px;
          background: #464e5b;
          }

          .style-switcher .theme-close i:hover {
          color: #464e5b;
          background: #fff;
          }

          .style-switcher .theme-heading {
          color: #fff;
          font-size: 14px;
          margin-bottom: 10px;
          text-transform: uppercase;
          }

          .style-switcher ul {
          margin-bottom: 0;
          }

          .style-switcher li {
          width: 20px;
          height: 20px;
          cursor: pointer;
          background: #c00;
          margin-right: 5px;
          display: inline-block;
          border: solid 1px #70747a;
          }

          .style-switcher li:hover,
          .style-switcher li.theme-active {
          margin-right: 3px;
          border: solid 2px #fff;
          }

          .style-switcher li.theme-default {
          background: #e67e22;
          }
          .style-switcher li.theme-blue {
          background: #3498db;
          }
          .style-switcher li.theme-orange {
          background: #d35400;
          }
          .style-switcher li.theme-red {
          background: #e74c3c;
          }
          .style-switcher li.theme-light {
          background: #ecf0f1;
          }

          /*Revolution Slider*/
          .bg-black-opacity {
          background: url(../img/sliders/revolution/bg-text.png) repeat;
          padding: 7px;
          text-shadow: none !important;
          }

          /*!
          * Bootstrap Responsive v2.3.2
          *
          * Copyright 2012 Twitter, Inc
          * Licensed under the Apache License v2.0
          * http://www.apache.org/licenses/LICENSE-2.0
          *
          * Designed and built with all the love in the world @twitter by @mdo and @fat.
          */

          .clearfix {
          *zoom: 1;
          }

          .clearfix:before,
          .clearfix:after {
          display: table;
          line-height: 0;
          content: "";
          }

          .clearfix:after {
          clear: both;
          }

          .hide-text {
          font: 0/0 a;
          color: transparent;
          text-shadow: none;
          background-color: transparent;
          border: 0;
          }

          .input-block-level {
          display: block;
          width: 100%;
          min-height: 30px;
          -webkit-box-sizing: border-box;
          -moz-box-sizing: border-box;
          box-sizing: border-box;
          }

          @-ms-viewport {
          width: device-width;
          }

          .hidden {
          display: none;
          visibility: hidden;
          }

          .visible-phone {
          display: none !important;
          }

          .visible-tablet {
          display: none !important;
          }

          .hidden-desktop {
          display: none !important;
          }

          .visible-desktop {
          display: inherit !important;
          }

          @media (min-width: 768px) and (max-width: 979px) {
          .hidden-desktop {
          display: inherit !important;
          }
          .visible-desktop {
          display: none !important ;
          }
          .visible-tablet {
          display: inherit !important;
          }
          .hidden-tablet {
          display: none !important;
          }
          }

          @media (max-width: 767px) {
          .hidden-desktop {
          display: inherit !important;
          }
          .visible-desktop {
          display: none !important;
          }
          .visible-phone {
          display: inherit !important;
          }
          .hidden-phone {
          display: none !important;
          }
          }

          .visible-print {
          display: none !important;
          }

          @media print {
          .visible-print {
          display: inherit !important;
          }
          .hidden-print {
          display: none !important;
          }
          }

          @media (min-width: 1200px) {
          .row {
          margin-left: -30px;
          *zoom: 1;
          }
          .row:before,
          .row:after {
          display: table;
          line-height: 0;
          content: "";
          }
          .row:after {
          clear: both;
          }
          [class*="span"] {
          float: left;
          min-height: 1px;
          margin-left: 30px;
          }
          .container,
          .navbar-static-top .container,
          .navbar-fixed-top .container,
          .navbar-fixed-bottom .container {
          width: 1170px;
          }
          .span12 {
          width: 1170px;
          }
          .span11 {
          width: 1070px;
          }
          .span10 {
          width: 970px;
          }
          .span9 {
          width: 870px;
          }
          .span8 {
          width: 770px;
          }
          .span7 {
          width: 670px;
          }
          .span6 {
          width: 570px;
          }
          .span5 {
          width: 470px;
          }
          .span4 {
          width: 370px;
          }
          .span3 {
          width: 270px;
          }
          .span2 {
          width: 170px;
          }
          .span1 {
          width: 70px;
          }
          .offset12 {
          margin-left: 1230px;
          }
          .offset11 {
          margin-left: 1130px;
          }
          .offset10 {
          margin-left: 1030px;
          }
          .offset9 {
          margin-left: 930px;
          }
          .offset8 {
          margin-left: 830px;
          }
          .offset7 {
          margin-left: 730px;
          }
          .offset6 {
          margin-left: 630px;
          }
          .offset5 {
          margin-left: 530px;
          }
          .offset4 {
          margin-left: 430px;
          }
          .offset3 {
          margin-left: 330px;
          }
          .offset2 {
          margin-left: 230px;
          }
          .offset1 {
          margin-left: 130px;
          }
          .row-fluid {
          width: 100%;
          *zoom: 1;
          }
          .row-fluid:before,
          .row-fluid:after {
          display: table;
          line-height: 0;
          content: "";
          }
          .row-fluid:after {
          clear: both;
          }
          .row-fluid [class*="span"] {
          display: block;
          float: left;
          width: 100%;
          min-height: 30px;
          margin-left: 2.564102564102564%;
          *margin-left: 2.5109110747408616%;
          -webkit-box-sizing: border-box;
          -moz-box-sizing: border-box;
          box-sizing: border-box;
          }
          .row-fluid [class*="span"]:first-child {
          margin-left: 0;
          }
          .row-fluid .controls-row [class*="span"] + [class*="span"] {
          margin-left: 2.564102564102564%;
          }
          .row-fluid .span12 {
          width: 100%;
          *width: 99.94680851063829%;
          }
          .row-fluid .span11 {
          width: 91.45299145299145%;
          *width: 91.39979996362975%;
          }
          .row-fluid .span10 {
          width: 82.90598290598291%;
          *width: 82.8527914166212%;
          }
          .row-fluid .span9 {
          width: 74.35897435897436%;
          *width: 74.30578286961266%;
          }
          .row-fluid .span8 {
          width: 65.81196581196582%;
          *width: 65.75877432260411%;
          }
          .row-fluid .span7 {
          width: 57.26495726495726%;
          *width: 57.21176577559556%;
          }
          .row-fluid .span6 {
          width: 48.717948717948715%;
          *width: 48.664757228587014%;
          }
          .row-fluid .span5 {
          width: 40.17094017094017%;
          *width: 40.11774868157847%;
          }
          .row-fluid .span4 {
          width: 31.623931623931625%;
          *width: 31.570740134569924%;
          }
          .row-fluid .span3 {
          width: 23.076923076923077%;
          *width: 23.023731587561375%;
          }
          .row-fluid .span2 {
          width: 14.52991452991453%;
          *width: 14.476723040552828%;
          }
          .row-fluid .span1 {
          width: 5.982905982905983%;
          *width: 5.929714493544281%;
          }
          .row-fluid .offset12 {
          margin-left: 105.12820512820512%;
          *margin-left: 105.02182214948171%;
          }
          .row-fluid .offset12:first-child {
          margin-left: 102.56410256410257%;
          *margin-left: 102.45771958537915%;
          }
          .row-fluid .offset11 {
          margin-left: 96.58119658119658%;
          *margin-left: 96.47481360247316%;
          }
          .row-fluid .offset11:first-child {
          margin-left: 94.01709401709402%;
          *margin-left: 93.91071103837061%;
          }
          .row-fluid .offset10 {
          margin-left: 88.03418803418803%;
          *margin-left: 87.92780505546462%;
          }
          .row-fluid .offset10:first-child {
          margin-left: 85.47008547008548%;
          *margin-left: 85.36370249136206%;
          }
          .row-fluid .offset9 {
          margin-left: 79.48717948717949%;
          *margin-left: 79.38079650845607%;
          }
          .row-fluid .offset9:first-child {
          margin-left: 76.92307692307693%;
          *margin-left: 76.81669394435352%;
          }
          .row-fluid .offset8 {
          margin-left: 70.94017094017094%;
          *margin-left: 70.83378796144753%;
          }
          .row-fluid .offset8:first-child {
          margin-left: 68.37606837606839%;
          *margin-left: 68.26968539734497%;
          }
          .row-fluid .offset7 {
          margin-left: 62.393162393162385%;
          *margin-left: 62.28677941443899%;
          }
          .row-fluid .offset7:first-child {
          margin-left: 59.82905982905982%;
          *margin-left: 59.72267685033642%;
          }
          .row-fluid .offset6 {
          margin-left: 53.84615384615384%;
          *margin-left: 53.739770867430444%;
          }
          .row-fluid .offset6:first-child {
          margin-left: 51.28205128205128%;
          *margin-left: 51.175668303327875%;
          }
          .row-fluid .offset5 {
          margin-left: 45.299145299145295%;
          *margin-left: 45.1927623204219%;
          }
          .row-fluid .offset5:first-child {
          margin-left: 42.73504273504273%;
          *margin-left: 42.62865975631933%;
          }
          .row-fluid .offset4 {
          margin-left: 36.75213675213675%;
          *margin-left: 36.645753773413354%;
          }
          .row-fluid .offset4:first-child {
          margin-left: 34.18803418803419%;
          *margin-left: 34.081651209310785%;
          }
          .row-fluid .offset3 {
          margin-left: 28.205128205128204%;
          *margin-left: 28.0987452264048%;
          }
          .row-fluid .offset3:first-child {
          margin-left: 25.641025641025642%;
          *margin-left: 25.53464266230224%;
          }
          .row-fluid .offset2 {
          margin-left: 19.65811965811966%;
          *margin-left: 19.551736679396257%;
          }
          .row-fluid .offset2:first-child {
          margin-left: 17.094017094017094%;
          *margin-left: 16.98763411529369%;
          }
          .row-fluid .offset1 {
          margin-left: 11.11111111111111%;
          *margin-left: 11.004728132387708%;
          }
          .row-fluid .offset1:first-child {
          margin-left: 8.547008547008547%;
          *margin-left: 8.440625568285142%;
          }
          input,
          textarea,
          .uneditable-input {
          margin-left: 0;
          }
          .controls-row [class*="span"] + [class*="span"] {
          margin-left: 30px;
          }
          input.span12,
          textarea.span12,
          .uneditable-input.span12 {
          width: 1156px;
          }
          input.span11,
          textarea.span11,
          .uneditable-input.span11 {
          width: 1056px;
          }
          input.span10,
          textarea.span10,
          .uneditable-input.span10 {
          width: 956px;
          }
          input.span9,
          textarea.span9,
          .uneditable-input.span9 {
          width: 856px;
          }
          input.span8,
          textarea.span8,
          .uneditable-input.span8 {
          width: 756px;
          }
          input.span7,
          textarea.span7,
          .uneditable-input.span7 {
          width: 656px;
          }
          input.span6,
          textarea.span6,
          .uneditable-input.span6 {
          width: 556px;
          }
          input.span5,
          textarea.span5,
          .uneditable-input.span5 {
          width: 456px;
          }
          input.span4,
          textarea.span4,
          .uneditable-input.span4 {
          width: 356px;
          }
          input.span3,
          textarea.span3,
          .uneditable-input.span3 {
          width: 256px;
          }
          input.span2,
          textarea.span2,
          .uneditable-input.span2 {
          width: 156px;
          }
          input.span1,
          textarea.span1,
          .uneditable-input.span1 {
          width: 56px;
          }
          .thumbnails {
          margin-left: -30px;
          }
          .thumbnails > li {
          margin-left: 30px;
          }
          .row-fluid .thumbnails {
          margin-left: 0;
          }
          }

          @media (min-width: 768px) and (max-width: 979px) {
          .row {
          margin-left: -20px;
          *zoom: 1;
          }
          .row:before,
          .row:after {
          display: table;
          line-height: 0;
          content: "";
          }
          .row:after {
          clear: both;
          }
          [class*="span"] {
          float: left;
          min-height: 1px;
          margin-left: 20px;
          }
          .container,
          .navbar-static-top .container,
          .navbar-fixed-top .container,
          .navbar-fixed-bottom .container {
          width: 724px;
          }
          .span12 {
          width: 724px;
          }
          .span11 {
          width: 662px;
          }
          .span10 {
          width: 600px;
          }
          .span9 {
          width: 538px;
          }
          .span8 {
          width: 476px;
          }
          .span7 {
          width: 414px;
          }
          .span6 {
          width: 352px;
          }
          .span5 {
          width: 290px;
          }
          .span4 {
          width: 228px;
          }
          .span3 {
          width: 166px;
          }
          .span2 {
          width: 104px;
          }
          .span1 {
          width: 42px;
          }
          .offset12 {
          margin-left: 764px;
          }
          .offset11 {
          margin-left: 702px;
          }
          .offset10 {
          margin-left: 640px;
          }
          .offset9 {
          margin-left: 578px;
          }
          .offset8 {
          margin-left: 516px;
          }
          .offset7 {
          margin-left: 454px;
          }
          .offset6 {
          margin-left: 392px;
          }
          .offset5 {
          margin-left: 330px;
          }
          .offset4 {
          margin-left: 268px;
          }
          .offset3 {
          margin-left: 206px;
          }
          .offset2 {
          margin-left: 144px;
          }
          .offset1 {
          margin-left: 82px;
          }
          .row-fluid {
          width: 100%;
          *zoom: 1;
          }
          .row-fluid:before,
          .row-fluid:after {
          display: table;
          line-height: 0;
          content: "";
          }
          .row-fluid:after {
          clear: both;
          }
          .row-fluid [class*="span"] {
          display: block;
          float: left;
          width: 100%;
          min-height: 30px;
          margin-left: 2.7624309392265194%;
          *margin-left: 2.709239449864817%;
          -webkit-box-sizing: border-box;
          -moz-box-sizing: border-box;
          box-sizing: border-box;
          }
          .row-fluid [class*="span"]:first-child {
          margin-left: 0;
          }
          .row-fluid .controls-row [class*="span"] + [class*="span"] {
          margin-left: 2.7624309392265194%;
          }
          .row-fluid .span12 {
          width: 100%;
          *width: 99.94680851063829%;
          }
          .row-fluid .span11 {
          width: 91.43646408839778%;
          *width: 91.38327259903608%;
          }
          .row-fluid .span10 {
          width: 82.87292817679558%;
          *width: 82.81973668743387%;
          }
          .row-fluid .span9 {
          width: 74.30939226519337%;
          *width: 74.25620077583166%;
          }
          .row-fluid .span8 {
          width: 65.74585635359117%;
          *width: 65.69266486422946%;
          }
          .row-fluid .span7 {
          width: 57.18232044198895%;
          *width: 57.12912895262725%;
          }
          .row-fluid .span6 {
          width: 48.61878453038674%;
          *width: 48.56559304102504%;
          }
          .row-fluid .span5 {
          width: 40.05524861878453%;
          *width: 40.00205712942283%;
          }
          .row-fluid .span4 {
          width: 31.491712707182323%;
          *width: 31.43852121782062%;
          }
          .row-fluid .span3 {
          width: 22.92817679558011%;
          *width: 22.87498530621841%;
          }
          .row-fluid .span2 {
          width: 14.3646408839779%;
          *width: 14.311449394616199%;
          }
          .row-fluid .span1 {
          width: 5.801104972375691%;
          *width: 5.747913483013988%;
          }
          .row-fluid .offset12 {
          margin-left: 105.52486187845304%;
          *margin-left: 105.41847889972962%;
          }
          .row-fluid .offset12:first-child {
          margin-left: 102.76243093922652%;
          *margin-left: 102.6560479605031%;
          }
          .row-fluid .offset11 {
          margin-left: 96.96132596685082%;
          *margin-left: 96.8549429881274%;
          }
          .row-fluid .offset11:first-child {
          margin-left: 94.1988950276243%;
          *margin-left: 94.09251204890089%;
          }
          .row-fluid .offset10 {
          margin-left: 88.39779005524862%;
          *margin-left: 88.2914070765252%;
          }
          .row-fluid .offset10:first-child {
          margin-left: 85.6353591160221%;
          *margin-left: 85.52897613729868%;
          }
          .row-fluid .offset9 {
          margin-left: 79.8342541436464%;
          *margin-left: 79.72787116492299%;
          }
          .row-fluid .offset9:first-child {
          margin-left: 77.07182320441989%;
          *margin-left: 76.96544022569647%;
          }
          .row-fluid .offset8 {
          margin-left: 71.2707182320442%;
          *margin-left: 71.16433525332079%;
          }
          .row-fluid .offset8:first-child {
          margin-left: 68.50828729281768%;
          *margin-left: 68.40190431409427%;
          }
          .row-fluid .offset7 {
          margin-left: 62.70718232044199%;
          *margin-left: 62.600799341718584%;
          }
          .row-fluid .offset7:first-child {
          margin-left: 59.94475138121547%;
          *margin-left: 59.838368402492065%;
          }
          .row-fluid .offset6 {
          margin-left: 54.14364640883978%;
          *margin-left: 54.037263430116376%;
          }
          .row-fluid .offset6:first-child {
          margin-left: 51.38121546961326%;
          *margin-left: 51.27483249088986%;
          }
          .row-fluid .offset5 {
          margin-left: 45.58011049723757%;
          *margin-left: 45.47372751851417%;
          }
          .row-fluid .offset5:first-child {
          margin-left: 42.81767955801105%;
          *margin-left: 42.71129657928765%;
          }
          .row-fluid .offset4 {
          margin-left: 37.01657458563536%;
          *margin-left: 36.91019160691196%;
          }
          .row-fluid .offset4:first-child {
          margin-left: 34.25414364640884%;
          *margin-left: 34.14776066768544%;
          }
          .row-fluid .offset3 {
          margin-left: 28.45303867403315%;
          *margin-left: 28.346655695309746%;
          }
          .row-fluid .offset3:first-child {
          margin-left: 25.69060773480663%;
          *margin-left: 25.584224756083227%;
          }
          .row-fluid .offset2 {
          margin-left: 19.88950276243094%;
          *margin-left: 19.783119783707537%;
          }
          .row-fluid .offset2:first-child {
          margin-left: 17.12707182320442%;
          *margin-left: 17.02068884448102%;
          }
          .row-fluid .offset1 {
          margin-left: 11.32596685082873%;
          *margin-left: 11.219583872105325%;
          }
          .row-fluid .offset1:first-child {
          margin-left: 8.56353591160221%;
          *margin-left: 8.457152932878806%;
          }
          input,
          textarea,
          .uneditable-input {
          margin-left: 0;
          }
          .controls-row [class*="span"] + [class*="span"] {
          margin-left: 20px;
          }
          input.span12,
          textarea.span12,
          .uneditable-input.span12 {
          width: 710px;
          }
          input.span11,
          textarea.span11,
          .uneditable-input.span11 {
          width: 648px;
          }
          input.span10,
          textarea.span10,
          .uneditable-input.span10 {
          width: 586px;
          }
          input.span9,
          textarea.span9,
          .uneditable-input.span9 {
          width: 524px;
          }
          input.span8,
          textarea.span8,
          .uneditable-input.span8 {
          width: 462px;
          }
          input.span7,
          textarea.span7,
          .uneditable-input.span7 {
          width: 400px;
          }
          input.span6,
          textarea.span6,
          .uneditable-input.span6 {
          width: 338px;
          }
          input.span5,
          textarea.span5,
          .uneditable-input.span5 {
          width: 276px;
          }
          input.span4,
          textarea.span4,
          .uneditable-input.span4 {
          width: 214px;
          }
          input.span3,
          textarea.span3,
          .uneditable-input.span3 {
          width: 152px;
          }
          input.span2,
          textarea.span2,
          .uneditable-input.span2 {
          width: 90px;
          }
          input.span1,
          textarea.span1,
          .uneditable-input.span1 {
          width: 28px;
          }
          }

          @media (max-width: 767px) {
          body {
          padding-right: 20px;
          padding-left: 20px;
          }
          .navbar-fixed-top,
          .navbar-fixed-bottom,
          .navbar-static-top {
          margin-right: -20px;
          margin-left: -20px;
          }
          .container-fluid {
          padding: 0;
          }
          .dl-horizontal dt {
          float: none;
          width: auto;
          clear: none;
          text-align: left;
          }
          .dl-horizontal dd {
          margin-left: 0;
          }
          .container {
          width: auto;
          }
          .row-fluid {
          width: 100%;
          }
          .row,
          .thumbnails {
          margin-left: 0;
          }
          .thumbnails > li {
          float: none;
          margin-left: 0;
          }
          [class*="span"],
          .uneditable-input[class*="span"],
          .row-fluid [class*="span"] {
          display: block;
          float: none;
          width: 100%;
          margin-left: 0;
          -webkit-box-sizing: border-box;
          -moz-box-sizing: border-box;
          box-sizing: border-box;
          }
          .span12,
          .row-fluid .span12 {
          width: 100%;
          -webkit-box-sizing: border-box;
          -moz-box-sizing: border-box;
          box-sizing: border-box;
          }
          .row-fluid [class*="offset"]:first-child {
          margin-left: 0;
          }
          .input-large,
          .input-xlarge,
          .input-xxlarge,
          input[class*="span"],
          select[class*="span"],
          textarea[class*="span"],
          .uneditable-input {
          display: block;
          width: 100%;
          min-height: 30px;
          -webkit-box-sizing: border-box;
          -moz-box-sizing: border-box;
          box-sizing: border-box;
          }
          .input-prepend input,
          .input-append input,
          .input-prepend input[class*="span"],
          .input-append input[class*="span"] {
          display: inline-block;
          width: auto;
          }
          .controls-row [class*="span"] + [class*="span"] {
          margin-left: 0;
          }
          .modal {
          position: fixed;
          top: 20px;
          right: 20px;
          left: 20px;
          width: auto;
          margin: 0;
          }
          .modal.fade {
          top: -100px;
          }
          .modal.fade.in {
          top: 20px;
          }
          }

          @media (max-width: 480px) {
          .nav-collapse {
          -webkit-transform: translate3d(0, 0, 0);
          }
          .page-header h1 small {
          display: block;
          line-height: 20px;
          }
          input[type="checkbox"],
          input[type="radio"] {
          border: 1px solid #ccc;
          }
          .form-horizontal .control-label {
          float: none;
          width: auto;
          padding-top: 0;
          text-align: left;
          }
          .form-horizontal .controls {
          margin-left: 0;
          }
          .form-horizontal .control-list {
          padding-top: 0;
          }
          .form-horizontal .form-actions {
          padding-right: 10px;
          padding-left: 10px;
          }
          .media .pull-left,
          .media .pull-right {
          display: block;
          float: none;
          margin-bottom: 10px;
          }
          .media-object {
          margin-right: 0;
          margin-left: 0;
          }
          .modal {
          top: 10px;
          right: 10px;
          left: 10px;
          }
          .modal-header .close {
          padding: 10px;
          margin: -10px;
          }
          .carousel-caption {
          position: static;
          }
          }

          @media (max-width: 979px) {
          body {
          padding-top: 0;
          }
          .navbar-fixed-top,
          .navbar-fixed-bottom {
          position: static;
          }
          .navbar-fixed-top {
          margin-bottom: 20px;
          }
          .navbar-fixed-bottom {
          margin-top: 20px;
          }
          .navbar-fixed-top .navbar-inner,
          .navbar-fixed-bottom .navbar-inner {
          padding: 5px;
          }
          .navbar .container {
          width: auto;
          padding: 0;
          }
          .navbar .brand {
          padding-right: 10px;
          padding-left: 10px;
          margin: 0 0 0 -5px;
          }
          .nav-collapse {
          clear: both;
          }
          .nav-collapse .nav {
          float: none;
          margin: 0 0 10px;
          }
          .nav-collapse .nav > li {
          float: none;
          }
          .nav-collapse .nav > li > a {
          margin-bottom: 2px;
          }
          .nav-collapse .nav > .divider-vertical {
          display: none;
          }
          .nav-collapse .nav .nav-header {
          color: #777777;
          text-shadow: none;
          }
          .nav-collapse .nav > li > a,
          .nav-collapse .dropdown-menu a {
          padding: 9px 15px;
          font-weight: bold;
          color: #777777;
          -webkit-border-radius: 3px;
          -moz-border-radius: 3px;
          border-radius: 3px;
          }
          .nav-collapse .btn {
          padding: 4px 10px 4px;
          font-weight: normal;
          -webkit-border-radius: 4px;
          -moz-border-radius: 4px;
          border-radius: 4px;
          }
          .nav-collapse .dropdown-menu li + li a {
          margin-bottom: 2px;
          }
          .nav-collapse .nav > li > a:hover,
          .nav-collapse .nav > li > a:focus,
          .nav-collapse .dropdown-menu a:hover,
          .nav-collapse .dropdown-menu a:focus {
          background-color: #f2f2f2;
          }
          .navbar-inverse .nav-collapse .nav > li > a,
          .navbar-inverse .nav-collapse .dropdown-menu a {
          color: #999999;
          }
          .navbar-inverse .nav-collapse .nav > li > a:hover,
          .navbar-inverse .nav-collapse .nav > li > a:focus,
          .navbar-inverse .nav-collapse .dropdown-menu a:hover,
          .navbar-inverse .nav-collapse .dropdown-menu a:focus {
          background-color: #111111;
          }
          .nav-collapse.in .btn-group {
          padding: 0;
          margin-top: 5px;
          }
          .nav-collapse .dropdown-menu {
          position: static;
          top: auto;
          left: auto;
          display: none;
          float: none;
          max-width: none;
          padding: 0;
          margin: 0 15px;
          background-color: transparent;
          border: none;
          -webkit-border-radius: 0;
          -moz-border-radius: 0;
          border-radius: 0;
          -webkit-box-shadow: none;
          -moz-box-shadow: none;
          box-shadow: none;
          }
          .nav-collapse .open > .dropdown-menu {
          display: block;
          }
          .nav-collapse .dropdown-menu:before,
          .nav-collapse .dropdown-menu:after {
          display: none;
          }
          .nav-collapse .dropdown-menu .divider {
          display: none;
          }
          .nav-collapse .nav > li > .dropdown-menu:before,
          .nav-collapse .nav > li > .dropdown-menu:after {
          display: none;
          }
          .nav-collapse .navbar-form,
          .nav-collapse .navbar-search {
          float: none;
          padding: 10px 15px;
          margin: 10px 0;
          border-top: 1px solid #f2f2f2;
          border-bottom: 1px solid #f2f2f2;
          -webkit-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.1), 0 1px 0 rgba(255, 255, 255, 0.1);
          -moz-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.1), 0 1px 0 rgba(255, 255, 255, 0.1);
          box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.1), 0 1px 0 rgba(255, 255, 255, 0.1);
          }
          .navbar-inverse .nav-collapse .navbar-form,
          .navbar-inverse .nav-collapse .navbar-search {
          border-top-color: #111111;
          border-bottom-color: #111111;
          }
          .navbar .nav-collapse .nav.pull-right {
          float: none;
          margin-left: 0;
          }
          .nav-collapse,
          .nav-collapse.collapse {
          height: 0;
          overflow: hidden;
          }
          .navbar .btn-navbar {
          display: block;
          }
          .navbar-static .navbar-inner {
          padding-right: 10px;
          padding-left: 10px;
          }
          }

          @media (min-width: 980px) {
          .nav-collapse.collapse {
          height: auto !important;
          overflow: visible !important;
          }
          }


        </style>
      </head>
      <body>
        <br />
        <div class="another-page">
          <div class="headline">
            <xsl:element name="img">
              <xsl:attribute name="src">
                <xsl:value-of select="Image"/>
              </xsl:attribute>
            </xsl:element>
            <h3>Solicitud de Servicio en Service Market</h3>
          </div>
          <h5>
            Estimado(a) <xsl:value-of select="CustomerName"/> :
          </h5>
          <br />
          <h5>
            Usted ha contactado con el sistema de atención al cliente de Service Market.
          </h5>
          <h5>
            A continuación le detallamos la respuesta a su consulta.
          </h5>
          <h5>
            <xsl:value-of select="Respuesta" />
          </h5>
          <br />
          <br />
          <h5>Atentamente,</h5>
          <h5>Service Market</h5>
        </div>

        <div class="footer">
          <div class="container">
            <div class="row-fluid">
              <div class="span12">
                <h6>Por favor no responda a este mensaje; fue enviado desde una dirección de correo electrónico no supervisada como parte del servicio que ofrece nuestro Sitio Web Service Market.</h6>
              </div>
            </div>
          </div>
        </div>

        <div class="copyright">
          <div class="container">
            <div class="row-fluid">
              <div class="span12">
                <p>
                  2015 &#169; Service Market. Todos los derechos reservados. <a href="xcomar-002-site3.smarterasp.net/Home/Policy">Política de Privacidad</a> | <a href="http://isrrasma2-001-site1.smarterasp.net/Home/Terms">Término de Servicios</a>
                </p>
              </div>
            </div>
          </div>
        </div>
      </body>
    </html>


  </xsl:template>
</xsl:stylesheet>

