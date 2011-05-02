xquery version "1.0-ml";
(:
Copyright 2009-2011 MarkLogic Corporation

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

:)
declare namespace dc = "http://purl.org/dc/elements/1.1/";

let $filename := xdmp:get-request-field("uid")
let $image := fn:doc($filename)/dc:metadata/dc:description[1]/node()
return  binary{xs:hexBinary(xs:base64Binary($image))}
